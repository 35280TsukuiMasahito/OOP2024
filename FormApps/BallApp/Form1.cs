using System.Net;

namespace BallApp {
    public partial class Form1 : Form {

        //Obj ball;
        //PictureBox pb;

        private List<Obj> balls = new List<Obj>(); //ボールインスタンス格納    
        private List<PictureBox> pbs = new List<PictureBox>();  //表示用

        public Form1() {
            InitializeComponent();

        }
        // フォームが最初にロードされるときに一度だけ実装される
        private void Form1_Load(object sender, EventArgs e) {

        }
        private void timer1_Tick(object sender, EventArgs e) {


           // ball.Move();
            //pb.Location = new Point((int)ball.PosX, (int)ball.PosY);

            for(int i = 0; i < balls.Count; i++) {
                balls[i].Move();
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);

            }

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            PictureBox pb = new PictureBox(); //画像を表示するコントロール  
            Obj ball = null;

            if (e.Button == MouseButtons.Left) {

                pb.Size = new Size(50, 50);


                ball = new SoccerBall(e.X - 30, e.Y - 30);

                pb.Image = ball.Image;
                pb.Location = new Point((int)ball.PosX, (int)ball.PosY);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Parent = this;
            }


            


            if (e.Button == MouseButtons.Right) {
                pb = new PictureBox(); //画像を表示するコントロール  
                pb.Size = new Size(20, 20);

                ball = new TennisBall(e.X - 30, e.Y - 30);

                pb.Image = ball.Image;
                pb.Location = new Point((int)ball.PosX, (int)ball.PosY);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Parent = this;
            }
            balls.Add(ball);
            pbs.Add(pb);
            timer1.Start();

        }

        private void timer2_Tick(object sender, EventArgs e) {
            //ball.Move();
            // pb.Location = new Point((int)ball.PosX, (int)ball.PosY);

            for (int i = 0; i < balls.Count; i++) {
                balls[i].Move();
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);

            }
        }
    }
}
