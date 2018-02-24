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
using XRpgLibrary.Controls;

namespace MonoRPG.GameScreens
{
    internal class SkillLabelSet
    {
        internal Label Label;
        internal LinkLabel LinkLabel;

        internal SkillLabelSet(Label label, LinkLabel linkLabel)
        {
            Label = label;
            LinkLabel = linkLabel;
        }
    }

    public class SkillScreen : BaseGameState
    {
        private int _skillPoints;
        private int _unassignedPoints;

        private PictureBox _backgroundImage;
        private Label _pointsRemaining;

        private readonly List<SkillLabelSet> _skillLabels = new List<SkillLabelSet>();

        private readonly Stack<string> _undoSkillStack = new Stack<string>();

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

            var Content = GameRef.Content;

            CreateControls(Content);
        }

        private void CreateControls(ContentManager content)
        {
            _backgroundImage = new PictureBox(
                Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);

            ControlManager.Add(_backgroundImage);

            var skillPath = content.RootDirectory + @"\Game\Skills\";
            var skillFiles = Directory.GetFiles(skillPath, "*.xnb");

            for (var i = 0; i < skillFiles.Length; ++i)
            {
                skillFiles[i] = @"Game\Skills\" +
                                Path.GetFileNameWithoutExtension(skillFiles[i]);
            }

            var nextControlPosition = new Vector2(300, 150);

            _pointsRemaining = new Label
            {
                Text = "Skill Points: " + _unassignedPoints,
                Position = nextControlPosition
            };

            nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;

            ControlManager.Add(_pointsRemaining);

            foreach (var s in skillFiles)
            {
                var data = content.Load<SkillData>(s);

                var label = new Label
                {
                    Text = data.Name,
                    Type = data.Name,
                    Position = nextControlPosition
                };

                var linkLabel = new LinkLabel
                {
                    TabStop = true,
                    Text = "+",
                    Type = data.Name,
                    Position = new Vector2(
                        nextControlPosition.X + 350,
                        nextControlPosition.Y)
                };

                nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;

                linkLabel.Selected += addSkillLabel_Selected;

                ControlManager.Add(label);
                ControlManager.Add(linkLabel);

                _skillLabels.Add(new SkillLabelSet(label, linkLabel));
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
            _undoSkillStack.Clear();
            StateManager.ChangeState(GameRef.GamePlayScreen);
        }

        private void undoLabel_Selected(object sender, EventArgs e)
        {
            if (_unassignedPoints == _skillPoints) return;

            _undoSkillStack.Pop();

            _unassignedPoints++;

            // Update the skill points for the appropriate skill
            _pointsRemaining.Text = "Skill Points: " + _unassignedPoints;
        }

        private void addSkillLabel_Selected(object sender, EventArgs e)
        {
            if (_unassignedPoints <= 0) return;

            var skillName = ((LinkLabel) sender).Type;
            _undoSkillStack.Push(skillName);
            --_unassignedPoints;

            // Update the skill points for the appropriate skill
            _pointsRemaining.Text = "Skill Points: " + _unassignedPoints;
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
    }
}

