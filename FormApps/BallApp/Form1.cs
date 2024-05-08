using System.Net;

namespace BallApp {
    public partial class Form1 : Form {

        SoccerBall soccerball;
        PictureBox pb;

        public Form1() {
            InitializeComponent();

        }
        // フォームが最初にロードされるときに一度だけ実装される
        private void Form1_Load(object sender, EventArgs e) {
            
        }
        private void timer1_Tick(object sender, EventArgs e) {


            soccerball.Move();
            pb.Location = new Point((int)soccerball.PosX, (int)soccerball.PosY);

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            pb = new PictureBox(); //画像を表示するコントロール  
            pb.Size = new Size(50,50);
 
             soccerball = new SoccerBall(e.X-30,e.Y-30);

            pb.Image = soccerball.Image;
            pb.Location = new Point((int)soccerball.PosX, (int)soccerball.PosY);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Parent = this;

            timer1.Start();
        }
    }
}
