using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    internal abstract class Obj {
        public Image Image { get; set; }
        public double PosX { get; set; }   
        public double PosY { get; set; }
        public double MoveX { get; set; }
        public double MoveY { get; set; }



        //コンストラクタ
        public Obj(double posX,double posY,String path) {
            PosX = posX;
            PosY = posY;
            Image = Image.FromFile(path);
        }

        //int tenniscout, soccercount;

        //移動メソッド
        public abstract bool Move(PictureBox pbBar,PictureBox pbBall);
        public abstract bool Move(Keys direction);



    }
}
