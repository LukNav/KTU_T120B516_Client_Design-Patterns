using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication.Controllers.Composite
{
    /// <summary>
    /// The 'Component' Treenode
    /// </summary>
    public interface ICompositePlayer
    {
        string Name { get; set; }
        int Health { get; set; }
    }

    /// <summary>
    /// The 'Composite' class
    /// </summary>
    public class PlayerComposite : ICompositePlayer, IEnumerable<ICompositePlayer>
    {
        private List<ICompositePlayer> _children = new List<ICompositePlayer>();

        public string Name { get; set; }
        public int Health { get; set; }

        public void AddChild(ICompositePlayer subordinate)
        {
            _children.Add(subordinate);
        }

        public void RemoveChild(ICompositePlayer subordinate)
        {
            _children.Remove(subordinate);
        }
        public void RemoveAllChildren()
        {
            _children.Clear();
        }
        public ICompositePlayer GetChild(int index)
        {
            return _children[index];
        }

        public IEnumerator<ICompositePlayer> GetEnumerator()
        {
            foreach (ICompositePlayer child in _children)
            {
                yield return child;
            }
        }
        public string Operation()
        {
            string message = string.Format("Player: {0}\n", Name);
            foreach (ICompositePlayer child in _children)
            {
                message += string.Format("\t Name: {0}, HP: {1}\n", Name, Health);
            }
            return message;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// The 'Leaf' class
    /// </summary>
    public class PawnLeaf : ICompositePlayer
    {
        public PawnLeaf(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public string Name { get; set; }
        public int Health { get; set; }
    } 
      /// <summary>
      /// The 'Leaf' class
      /// </summary>
    public class TowerLeaf : ICompositePlayer
    {
        public TowerLeaf(int health)
        {
            Name = "Tower";
            Health = health;
        }

        public string Name { get; set; }
        public int Health { get; set; }
    }
}

