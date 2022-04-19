using System.Runtime.Serialization;

namespace ems_api.DTOs;

[DataContract]
public class WorkdayDto {
    [DataMember] public int UserId { get; init; }

    [DataMember] public int WorkdayId { get; init; }

    [DataMember] public DateTime Date { get; set; }

    [DataMember] public TimeSpan TimeFrom { get; set; }

    [DataMember] public TimeSpan TimeTo { get; set; }
}