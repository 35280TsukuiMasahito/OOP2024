using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    internal class Bar : Obj {

        public Bar(double xp, double yp)
    : base(xp, yp, @"Picture\Bar.png") {
            MoveX = 20; //移動量設定
            MoveY = 0;
        }


        public override int Move(PictureBox pbBar, PictureBox pbBall) {
            return 0;
        }

        public override int Move(Keys direction) {
            
            
            if (direction == Keys.Right) {
                if (PosX > 630) {
                    MoveX = 0;
                }
                    PosX += MoveX;
            } else if(direction == Keys.Left) {
                if ( PosX < 15) {
                    MoveX = 0;
                }
                    PosX -= MoveX;
            }
            MoveX = 20;
            return 1;

        }
    }
}
