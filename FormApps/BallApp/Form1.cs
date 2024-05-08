using System.Net;

namespace BallApp {
    public partial class Form1 : Form {

        Obj ball;
        PictureBox pb;

        public Form1() {
            InitializeComponent();

        }
        // フォームが最初にロードされるときに一度だけ実装される
        private void Form1_Load(object sender, EventArgs e) {

        }
        private void timer1_Tick(object sender, EventArgs e) {


            ball.Move();
            pb.Location = new Point((int)ball.PosX, (int)ball.PosY);
                
            

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {

            if (e.Button == MouseButtons.Left) {
                pb = new PictureBox(); //画像を表示するコントロール  
                pb.Size = new Size(50, 50);

                ball = new SoccerBall(e.X - 30, e.Y - 30);

                pb.Image = ball.Image;
                pb.Location = new Point((int)ball.PosX, (int)ball.PosY);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Parent = this;

                timer1.Start();
                timer2.Stop();
            }
            else if (e.Button == MouseButtons.Right) {
                pb = new PictureBox(); //画像を表示するコントロール  
                pb.Size = new Size(20, 20);

                ball = new TennisBall(e.X - 30, e.Y - 30);

                pb.Image = ball.Image;
                pb.Location = new Point((int)ball.PosX, (int)ball.PosY);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Parent = this;

                timer2.Start();
                timer1.Stop();
                
            }


        }

        private void timer2_Tick(object sender, EventArgs e) {
            ball.Move();
            pb.Location = new Point((int)ball.PosX, (int)ball.PosY);
        }
    }
}
