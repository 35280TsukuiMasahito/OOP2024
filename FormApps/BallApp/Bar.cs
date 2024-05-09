using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    internal class Bar : Obj {
        public Bar(double xp, double yp)
    : base(xp, yp, @"Picture\Bar.png") {
            MoveX = 10; //移動量設定
            MoveY = 0;
        }


        public override bool Move() {
            return true;
        }

        public override bool Move(Keys direction) {
            
            
            if (direction == Keys.Right) {
                if (PosX > 630) {
                    MoveX = 0;
                }
                    PosX += MoveX;
            } else if(direction == Keys.Left) {
                if ( PosX < 10) {
                    MoveX = 0;
                }
                    PosX -= MoveX;
            }
            MoveX = 10;
            return true;

        }
    }
}
