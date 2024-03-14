namespace Football_Transfers_Validation_API.Models;

using System;

public class Transfer
{
    public int Id { get; set; }

    public double TransferValue { get; set; }

    public TransferState TransferState { get; set; }

    public double? ComissionTax { get; set; }

    public DateTime TransferDate { get; set; }

    public int FromClubId { get; set; }

    public int ToClubId { get; set; }

    public int PlayerId { get; set; }
}
