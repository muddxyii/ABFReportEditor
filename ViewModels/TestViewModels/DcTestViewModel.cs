namespace ABFReportEditor.ViewModels.TestViewModels;

public class DcTestViewModel : BaseTestViewModel
{
    protected override bool ValidateFields()
    {
        // Do base validation
        if (!base.ValidateFields()) return false;
        
        // Do DC Specific Checks
        if (string.IsNullOrEmpty(CheckValve1) || string.IsNullOrEmpty(CheckValve2)) return false;
        
        return true;
    }
    
    protected override bool IsBackflowPassing()
    {
        // Return false if any component has leaked or failed to open
        if (CheckValve1Leaked || CheckValve2Leaked) return false;
        
        // Parse input values to decimal for numerical comparison
        if (!decimal.TryParse(CheckValve1, out decimal checkValve1Value) ||
            !decimal.TryParse(CheckValve2, out decimal checkValve2Value))
        {
            return false; // Invalid input values
        }
        
        // Check if Check Valve 1 or CV2 is <= 1
        if (checkValve1Value <= 1.0m || checkValve2Value <= 1.0m)
        {
            return false;
        }

        return true;
    }
}