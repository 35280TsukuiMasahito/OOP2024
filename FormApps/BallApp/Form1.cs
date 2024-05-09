using System.Drawing.Printing;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace BallApp {
    public partial class Form1 : Form {

        //Obj ball;
        //PictureBox pb;

        private List<Obj> balls = new List<Obj>(); //�{�[���C���X�^���X�i�[    
        private List<PictureBox> pbs = new List<PictureBox>();  //�\���p

        //�o�[�p
        private Bar bar;
        private PictureBox pbBar;

        public Form1() {
            InitializeComponent();

        }
        // �t�H�[�����ŏ��Ƀ��[�h�����Ƃ��Ɉ�x�������������
        private void Form1_Load(object sender, EventArgs e) {
            this.Text = "BallApp SoccerBall:0 TennisBall:0";

            bar = new Bar(340, 500);
            pbBar = new PictureBox();
            pbBar.Image = bar.Image;
            pbBar.Location = new Point((int)bar.PosX, (int)bar.PosY);
            pbBar.Size = new Size(150, 10);
            pbBar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBar.Parent = this;
            

        }
        private void timer1_Tick(object sender, EventArgs e) {


            // ball.Move();
            //pb.Location = new Point((int)ball.PosX, (int)ball.PosY);

            for (int i = 0; i < balls.Count; i++) {
                balls[i].Move(pbBar, pbs[i]);
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);

            }

            this.Text = "BallApp SoccerBall:" + SoccerBall.Count + "TennisBall:" + TennisBall.Count;

        }

        //�}�E�X�N���b�N�C�x���g�n���h��
        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            PictureBox pb = new PictureBox(); //�摜��\������R���g���[��  
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
                pb = new PictureBox(); //�摜��\������R���g���[��  
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

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
                bar.Move(e.KeyCode);
                pbBar.Location = new Point((int)bar.PosX, (int)bar.PosY);
            
            
        }
    }
}
