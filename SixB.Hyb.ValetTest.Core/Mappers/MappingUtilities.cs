using Newtonsoft.Json;
using SixB.Hyb.ValetTest.Core.Models.DTOs;
using SixB.Hyb.ValetTest.Core.Models.ViewModels;

namespace SixB.Hyb.ValetTest.Core.Mappers
{
    public static class MappingUtilities
    {
        // Ideally this would be replaced with automapper, or even custom generics.
        // I don't forsee having to convert anything else currently, so this will do for now

        public static BookingDto ConvertToDto(this BookingViewModel source)
        {
            var sourceAsJson = JsonConvert.SerializeObject(source);

            var targetAsObject = JsonConvert.DeserializeObject<BookingDto>(sourceAsJson);

            if (targetAsObject == null)
            {
                throw new FormatException();
            }

            return targetAsObject;
        }

        public static BookingViewModel ConvertToViewModel(this BookingDto source)
        {
            var sourceAsJson = JsonConvert.SerializeObject(source);

            var targetAsObject = JsonConvert.DeserializeObject<BookingViewModel>(sourceAsJson);

            if (targetAsObject == null)
            {
                throw new FormatException();
            }

            targetAsObject.FlexibilityDayDisplay = source.FlexibilityDay?.Name;
            targetAsObject.VehicleSizeDisplay = source.VehicleSize?.Name;

            return targetAsObject;
        }

        public static IList<BookingViewModel> ConvertToViewModelList(IList<BookingDto> source)
        {
            var list = new List<BookingViewModel>();

            foreach (var item in source)
            {
                list.Add(item.ConvertToViewModel());
            }

            return list;
        }
    }
}
