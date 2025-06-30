using AutoMapper;
using HealthStore.API.Models.Domain;
using HealthStore.API.Models.DTOs;

namespace HealthStore.API.Mapper;

public class AutoMapperProfiles: Profile{
    public AutoMapperProfiles()
    {
        CreateMap<Vitals, AddVitalsDTO>().ReverseMap();
        CreateMap<Patient, PatientDTO>().ReverseMap();
        CreateMap<Patient, UpdatePatientDTO>().ReverseMap();
        CreateMap<Vitals, AddVitalsDTO>().ReverseMap();
    }
}