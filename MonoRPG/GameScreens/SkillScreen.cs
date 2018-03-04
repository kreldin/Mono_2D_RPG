using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.Skills;
using XRpgLibrary;
using XRpgLibrary.Characters;
using XRpgLibrary.Controls;

namespace MonoRPG.GameScreens
{
    internal class SkillLabelSet
    {
        internal Label Label;
        internal Label SkillLabel;
        internal LinkLabel LinkLabel;
        internal int SkillValue;

        internal SkillLabelSet(Label label, Label skillLabel, LinkLabel linkLabel)
        {
            Label = label;
            SkillLabel = skillLabel;
            LinkLabel = linkLabel;
            SkillValue = 0;
        }
    }

    public class SkillScreen : BaseGameState
    {
        private int _skillPoints;
        private int _unassignedPoints;

        private PictureBox BackgroundImage { get; set; }
        private Label PointsRemaining { get; set; }

        private Character Target { get; set; }

        private List<SkillLabelSet> SkillLabels { get; }= new List<SkillLabelSet>();

        private Stack<string> UndoSkillStack { get; } = new Stack<string>();

        private EventHandler _linkLabelEventHandler;

        public int SkillPoints
        {
            get => _skillPoints;
            set
            {
                _skillPoints = value;
                _unassignedPoints = value;
            }
        }

        public SkillScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
            _linkLabelEventHandler = addSkillLabel_Selected;
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            var content = GameRef.Content;

            CreateControls(content);
        }

        private void CreateControls(ContentManager content)
        {
            BackgroundImage = new PictureBox(
                Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);

            ControlManager.Add(BackgroundImage);

            var nextControlPosition = new Vector2(300, 150);

            PointsRemaining = new Label
            {
                Text = "Skill Points: " + _unassignedPoints,
                Position = nextControlPosition
            };

            nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;

            ControlManager.Add(PointsRemaining);

            foreach (var s in DataManager.Skills.Keys)
            {
                var data = content.Load<SkillData>(s);

                var label = new Label
                {
                    Text = data.Name,
                    Type = data.Name,
                    Position = nextControlPosition
                };

                var sLabel = new Label()
                {
                    Text = "0",
                    Position = new Vector2(
                        nextControlPosition.X + 300,
                        nextControlPosition.Y)
                };
                
                var linkLabel = new LinkLabel
                {
                    TabStop = true,
                    Text = "Add",
                    Type = data.Name,
                    Position = new Vector2(
                        nextControlPosition.X + 390,
                        nextControlPosition.Y)
                };

                nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;

                linkLabel.Selected += addSkillLabel_Selected;

                ControlManager.Add(label);
                ControlManager.Add(sLabel);
                ControlManager.Add(linkLabel);

                SkillLabels.Add(new SkillLabelSet(label, sLabel, linkLabel));
            }

            nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;

            var undoLabel = new LinkLabel
            {
                Text = "Undo",
                Position = nextControlPosition,
                TabStop = true
            };

            undoLabel.Selected += undoLabel_Selected;
            nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;

            ControlManager.Add(undoLabel);

            var acceptLabel = new LinkLabel
            {
                Text = "Accept Changes",
                Position = nextControlPosition,
                TabStop = true
            };

            acceptLabel.Selected += acceptLabel_Selected;

            ControlManager.Add(acceptLabel);
            ControlManager.NextControl();
        }

        private void acceptLabel_Selected(object sender, EventArgs e)
        {
            UndoSkillStack.Clear();
            Transition(ChangeType.Change, GameRef.GamePlayScreen);
        }

        private void undoLabel_Selected(object sender, EventArgs e)
        {
            if (_unassignedPoints == _skillPoints) return;

            var skillName = UndoSkillStack.Peek();

            UndoSkillStack.Pop();

            ++_unassignedPoints;

            foreach (var set in SkillLabels)
            {
                if (set.LinkLabel.Type != skillName) continue;

                --set.SkillValue;
                set.SkillLabel.Text = set.SkillValue.ToString();
                Target.Entity.Skills[skillName].DecreaseSkill(1);
            }

            // Update the skill points for the appropriate skill
            PointsRemaining.Text = "Skill Points: " + _unassignedPoints;
        }

        private void addSkillLabel_Selected(object sender, EventArgs e)
        {
            if (_unassignedPoints <= 0) return;

            var skillName = ((LinkLabel) sender).Type;
            UndoSkillStack.Push(skillName);
            --_unassignedPoints;

            foreach (var set in SkillLabels)
            {
                if (set.LinkLabel.Type != skillName) continue;

                ++set.SkillValue;
                set.SkillLabel.Text = set.SkillValue.ToString();
                Target.Entity.Skills[skillName].IncreaseSkill(1);
            }

            // Update the skill points for the appropriate skill
            PointsRemaining.Text = "Skill Points: " + _unassignedPoints;
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();
            base.Draw(gameTime);
            ControlManager.Draw(GameRef.SpriteBatch);
            GameRef.SpriteBatch.End();
        }

        public void SetTarget(Character character)
        {
            Target = character;

            foreach (var set in SkillLabels)
            {
                set.SkillValue = Target.Entity.Skills[set.Label.Text].SkillValue;
                set.SkillLabel.Text = set.SkillValue.ToString();
            }
        }
    }
}

