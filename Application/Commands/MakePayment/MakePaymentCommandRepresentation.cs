namespace Application.Commands.MakePayment;

public class MakePaymentCommandRepresentation
{
    public decimal TotalPaidAmount { get; set; }
    public decimal RemainingAmount { get; set; }
    public bool IsEligibleToApprove { get; set; }
}