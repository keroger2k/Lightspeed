﻿using System;

namespace Lightspeed.Model
{
    public class Category
    {
        public int categoryID { get; set; }
        public string name { get; set; }
        public string nodeDepth { get; set; }
        public string fullPathName { get; set; }
        public int leftNode { get; set; }
        public int rightNode { get; set; }
        public int parentID { get; set; }
        public DateTime timeStamp { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}", this.categoryID, this.name);
        }
    }    
}
