using System.Collections.Generic;
using System.Linq;

namespace DemoApp
{
    public interface IFileSystemElement
    {
        decimal GetSize();
    }
    class File : IFileSystemElement
    {
        private readonly decimal _size;

        public File(decimal size)
        {
            _size = size;
        }

        public decimal GetSize()
        {
            return _size;
        }
    }

    class Folder : IFileSystemElement
    {
        private readonly decimal _size;
        private List<IFileSystemElement> children = new List<IFileSystemElement>();

        public Folder(decimal size = 0)
        {
            _size = size;
        }

        public decimal GetSize()
        {
            decimal size = 0;
            foreach(IFileSystemElement child in children) 
            {
                size += child.GetSize();
            }
            return size + _size;
        }

        public void AddChild(IFileSystemElement element)
        {
            children.Add(element);
        }
    }
}