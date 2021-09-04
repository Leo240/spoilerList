using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Image : IComparable<Image>, IEnumerable<Image>
    {
        private List<Image> _images = new List<Image>();
        public string Name { get; set; }
        public int Height { get; set; }

        public void Add(Image image)
        {
            _images.Add(image);
        }

        public Image(string name, int height)
        {
            Name = name;
            Height = height;
        }

        public int CompareTo(Image other)
        {
            return Height.CompareTo(other.Height);
        }

        public IEnumerator<Image> GetEnumerator()
        {
            return _images.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
