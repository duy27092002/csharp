using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3H_K34DL1_CORE
{
    public class Laptop
    {
        private string name_;

        private string color_;

        private float weight_;

        private float width_;

        private float height_;

        private float sizeScreen_;

        private string  origin_;

        private string brand_;

        public string Name
        {
            get
            {
                return name_;
            }

            set
            {
                name_ = value;
            }
        }

        public string Color
        {
            get
            {
                return color_;
            }

            set
            {
                color_ = value;
            }
        }

        public float  Weight
        {
            get
            {
                return weight_;
            }

            set
            {
                weight_ = value;
            }
        }

        public float Width
        {
            get
            {
                return width_;
            }

            set
            {
                width_ = value;
            }
        }

        public float Height
        {
            get
            {
                return height_;
            }

            set
            {
                height_ = value;
            }
        }

        public float SizeScreen
        {
            get
            {
                return sizeScreen_;
            }

            set
            {
                sizeScreen_ = value;
            }
        }

        public string Origin
        {
            get
            {
                return origin_;
            }

            set
            {
                origin_ = value;
            }
        }

        public string Brand
        {
            get
            {
                return brand_;
            }

            set
            {
                brand_ = value;
            }
        }
    }
}
