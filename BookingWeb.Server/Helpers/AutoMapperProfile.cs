using AutoMapper;
using BookingWeb.Server.Models;
using BookingWeb.Server.ViewModels;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace BookingWeb.Server.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<PhieuDatVM, Phieudat>();
    }
}