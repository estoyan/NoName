using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noleggio.Common
{
    public static class NoleggioConstants
    {
        public const int UserMimiumAge = 18;

        public const int UserClassMinimumStringLenght = 2;
        public const int UserFirstNameMaximumLenght = 30;
        public const int UserLastNameMaximumLenght = UserFirstNameMaximumLenght;
        public const int UserAddressMaximumLength = 30;
        public const int UserCityMaximumLength = 30;

        public const int CategoryNameMinLenght = 3;
        public const int CategoryNameMaxLenght = 30;

        public const int CommentDescriptionMaxLength = 200;

        public const int MinRate = 0;
        public const int MaxRate = 5;

        public const int CommentMaxLength = 200;
        public const int ImagePathLength = 100;
        public const int DescriptionMaxLength = 200;

        public const int RentItemNameMaximumLength = 30;
        public const int RentItemLocationMaximumLength = 30;

        public const int PagingSize = 1;


    }
}
