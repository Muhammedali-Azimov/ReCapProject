using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        public void Add(Color color);
        public List<Color> GetAll();
    }
}
