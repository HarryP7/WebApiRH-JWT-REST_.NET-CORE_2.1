﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRH.Models
{
    public class GroupChat
    {
        [Key]
        public Guid Uid { get; set; }
        [Display(Name = "Автор"), ForeignKey(nameof(Author))]
        public Guid Fk_Author { get; set; }
        [Required]
        [Display(Name = "Сообщение"), Column(TypeName = "nvarchar(MAX)")]
        public string Text { get; set; }
        [Required]
        [Display(Name = "Локальная группа"), ForeignKey(nameof(LocalGroup))]
        public Guid Fk_LocalGroup { get; set; }
        [Display(Name = "Картинка"), ForeignKey(nameof(Image))]
        public Nullable<Guid> Fk_Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public bool Removed { get; set; }

        [InverseProperty(nameof(ChatReply.GroupChat))]
        public virtual ICollection<ChatReply> GroupReplys { get; set; } = new HashSet<ChatReply>();
        [JsonIgnore]
        public virtual LocalGroup LocalGroup { get; set; }
        public virtual User Author { get; set; }
        public virtual Images Image { get; set; }
    }
}