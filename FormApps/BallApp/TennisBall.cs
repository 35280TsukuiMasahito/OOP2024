using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    internal class TennisBall : Obj {
        Random random = new Random();
        public static int Count {  get; set; }
        public TennisBall(double xp, double yp)
            : base(xp, yp, @"Picture\tennis_ball.png") {
            MoveX = random.Next(-30,30); //移動量設定
            MoveY = random.Next(-30,30);
            Count++;
        }

        public override bool Move() {
            PosX += MoveX;
            PosY += MoveY;

            if (PosX > 770 || PosX < 0) {
                //移動量の反転
                MoveX = -MoveX;
            }

            if (PosY > 535 || PosY < 0) {
                MoveY = -MoveY;
            }

            return true;


        }

        public override bool Move(Keys direction) {
            throw new NotImplementedException();
        }
    }
}