using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.ViewModels.Albums
{
    public class AllAlbumsViewModel
    {
        public ICollection<AlbumListViewModel> Albums { get; set; }
    }
}
