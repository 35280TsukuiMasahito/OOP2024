using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    internal class SoccerBall : Obj {
        Random random = new Random();
        public static int Count { get; set; }
        public SoccerBall(double xp, double yp)
            : base(xp, yp, @"Picture\soccer_ball.png") {

            MoveX = random.Next(-30, 30); //移動量設定
            MoveY = random.Next(-30, 30);
            Count++;
        }
        //戻り値: 0...移動OK 1...落下した 2...バーに当たった
        public override int Move(PictureBox pbBar, PictureBox pbBall) {
            Rectangle rBar = new Rectangle(pbBar.Location.X, pbBar.Location.Y, pbBar.Width, pbBar.Height);

            Rectangle rBall = new Rectangle(pbBall.Location.X, pbBall.Location.Y, pbBall.Width, pbBall.Height);



            if (PosX > 750 || PosX < 0) {
                //移動量の反転
                MoveX = -MoveX;
            }

            if (PosY > 500 || PosY < 0) {
                MoveY = -MoveY;

            }

            if (PosY > 500) { //下に落下した？

                return 1;
            }

            if (rBar.IntersectsWith(rBall)) {
                MoveY = -MoveY;

                PosX += MoveX;
                PosY += MoveY;
                return 2;
            }

            PosX += MoveX;
            PosY += MoveY;
            return 0;
        }

        public override int Move(Keys direction) {
            throw new NotImplementedException();
        }
    }
}
