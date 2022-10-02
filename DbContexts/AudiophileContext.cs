using System;
using System.Collections.Generic;
using AudiophileBE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AudiophileBE.DbContexts
{
    public partial class AudiophileContext : DbContext
    {
        public AudiophileContext(DbContextOptions<AudiophileContext> options)
          : base(options)
        {
        }

        public DbSet<Post>? Post { get; set; }

        public DbSet<Comment>? Comment { get; set; }

        public DbSet<User>? Users { get; set; }
    }
}
