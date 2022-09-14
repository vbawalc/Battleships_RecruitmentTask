using System;
using System.Drawing;
using System.Windows.Forms;

namespace Battleships
{
    public partial class GameForm : Form
    {
        private GameState gamestate;
        private Button[,] _boardButtons;
        const int tileSize = 40;
        const int gridSize = 10;
        Color clr1 = Color.CadetBlue;
        Color clr2 = Color.White;
        public enum MoveResult { hit, miss, sink, gameover };
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            gamestate = new GameState();

            // Create buttons that represent tiles on a board.
            _boardButtons = new Button[gridSize, gridSize];
            for (int row = 0; row < gridSize; row++)
            {
                for (int column = 0; column < gridSize; column++)
                {
                    
                    var tileButton = new Button
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * row, tileSize * column),                        
                    };

                    int x = row;
                    int y = column; //Create copy of iterator cannot use loop variables to control buttons because functions are created with reference values after loop is over
                    // add Control to buttons
                    tileButton.Click += (sender1, e1) =>
                    {
                        gamestate.aiplayer.Playerboard.Tiles[x, y].Attack();
                        ShowMoveResult(new Coordinates(x, y));
                        if (!gamestate.aiplayer.Playerboard.Tiles[x, y].IsWater())
                        {
                            _boardButtons[x, y].BackColor = Color.Red;
                        }
                        else
                        {
                            _boardButtons[x, y].BackColor = Color.Black;
                        }
                        tileButton.Enabled = false; //Disable button after it has been clicked
                    };
                    Controls.Add(tileButton);
                    _boardButtons[row, column] = tileButton;

                    // color the backgrounds
                    tileButton.BackColor = (column + row) % 2 != 0 ? clr1 : clr2;
                }
            }
        }
        private void ShowMoveResult(Coordinates coordinates)
        {
            if(gamestate.HitOrSink(coordinates)==GameState.MoveResult.hit)
            {
                MessageBox.Show("Hit");
                return;
            }
            if (gamestate.HitOrSink(coordinates) == GameState.MoveResult.sink)
            {
                MessageBox.Show("Sink");
                return;
            }
            if (gamestate.HitOrSink(coordinates) == GameState.MoveResult.miss)
            {
                MessageBox.Show("Miss");
                return;
            }
            if (gamestate.HitOrSink(coordinates) == GameState.MoveResult.gameover)
            {               
                MessageBox.Show("Game Over");
                Close();         
                return;
            }
        }
    }
}
