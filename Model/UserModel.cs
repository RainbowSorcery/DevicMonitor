using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicMonitor.Model
{

    [Table("t_user")] 
    public class UserModel
    {
        [Key]
        [Column("user_id")]
        public int userId { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("password")]

        public string Password { get; set; }
        [Column("real_name")]

        public string RealName { get; set; }
        [Column("is_can_login")]

        public int IsCanLogin { get; set; }
        [Column("is_vailidation")]

        public int IsVaildation { get; set; }
        [Column("is_teacher")]

        public int IsTeacher { get; set; }
        [Column("avatar")]

        public string Avatar { get; set; }
        [Column("gender")]

        public int Gender { get; set; }
    }
}
