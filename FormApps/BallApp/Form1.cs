namespace BallApp {
    public partial class Form1 : Form {
        private double posX;//X���W
        private double posY;//Y���W
        private double moveX;
        private double moveY;

        public Form1() {
            InitializeComponent();

            moveX = moveY = 3;
        }
        // �t�H�[�����ŏ��Ƀ��[�h�����Ƃ��Ɉ�x�������������
        private void Form1_Load(object sender, EventArgs e) {
            //this.BackColor = Color.Green;
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e) {

            this.Text = pbBall.Location.ToString();

            

            if (pbBall.Location.X > 750 || pbBall.Location.X < 0) {
                moveX = -moveX;
            }

            if(pbBall.Location.Y > 500 || pbBall.Location.Y < 0) {
                moveY = -moveY;
            }

            posX += moveX;
            posY += moveY;

            pbBall.Location = new Point((int)posX, (int)posY);
        }

    }
}
