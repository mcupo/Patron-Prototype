using System;

using System.Collections.Generic;

namespace DoFactory.GangOfFour.Prototype.RealWorld

{

    class MainApp

    {

        static void Main()

        {

            ColorManager colormanager = new ColorManager();

            //Inicializo con colores estandar

            colormanager["red"] = new Color(255, 0, 0);

            colormanager["green"] = new Color(0, 255, 0);

            colormanager["blue"] = new Color(0, 0, 255);

            //Agrego colores personalizados

            colormanager["angry"] = new Color(255, 54, 0);

            colormanager["peace"] = new Color(128, 211, 128);

            colormanager["flame"] = new Color(211, 34, 20);

            //El usuario clona los siguientes colores

            Color color1 = colormanager["red"].Clone() as Color;

            Color color2 = colormanager["peace"].Clone() as Color;

            Color color3 = colormanager["flame"].Clone() as Color;

            Console.ReadKey();

        }

    }

    //La clase abstracta Prototipica

    abstract class ColorPrototype

    {

        public abstract ColorPrototype Clone();

    }

    class Color : ColorPrototype

    {

        private int _red;

        private int _green;

        private int _blue;

        public Color(int red, int green, int blue)

        {

            this._red = red;

            this._green = green;

            this._blue = blue;

        }

        //Crea una copia SUPERFICIAL

        public override ColorPrototype Clone()

        {

            Console.WriteLine(

              "Clonando color RGB: {0,3},{1,3},{2,3}",

              _red, _green, _blue);

            return this.MemberwiseClone() as ColorPrototype;

        }

    }

    class ColorManager

    {

        private Dictionary<string, ColorPrototype> _colors = new Dictionary<string, ColorPrototype>();

        // Indexer

        public ColorPrototype this[string key]

        {

            get { return _colors[key]; }

            set { _colors.Add(key, value); }

        }

    }

}
