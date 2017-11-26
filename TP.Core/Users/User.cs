using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Core.Users
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public DateTime Created { get; set; }

        /// <summary>
        /// 用户唯一码
        /// </summary>
        public Guid Guid { get; set; }
    }
}
