using ReportFlow.Models;

namespace ReportFlow.ViewModels.TestViewModels;

public class DcTestViewModel(ReportData report, bool isInitialTest) : BaseTestViewModel(report, isInitialTest)
{
    protected override async Task<bool> ValidateFields()
    {
        // Do base validation
        if (!await base.ValidateFields()) return false;

        // Do DC Specific Checks
        if (!await AreFieldsValid(new (string Value, string Name)[]
            {
                (CheckValve1 ?? "", "Check Valve #1"),
                (CheckValve2 ?? "", "Check Valve #2")
            })) return false;

        return true;
    }

    protected override bool IsBackflowPassing()
    {
        // Return false if any component has leaked or failed to open
        if (!CheckValve1Ct || !CheckValve2Ct) return false;

        // Parse input values to decimal for numerical comparison
        if (!decimal.TryParse(CheckValve1, out var checkValve1Value) ||
            !decimal.TryParse(CheckValve2, out var checkValve2Value))
            return false; // Invalid input values

        // Check if Check Valve 1 or CV2 is <= 1
        if (checkValve1Value < 1.0m || checkValve2Value < 1.0m) return false;

        return true;
    }

    public DcTestViewModel() : this(new ReportData(), true)
    {
    }
}