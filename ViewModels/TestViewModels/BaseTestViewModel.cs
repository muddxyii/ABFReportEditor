using ABFReportEditor.ViewModels.FinalViewModels;
using ABFReportEditor.ViewModels.RepairViewModels;

namespace ABFReportEditor.ViewModels.TestViewModels;

public abstract class BaseTestViewModel : BaseBackflowViewModel
{
    #region Dropdown Items
    
    #region ALl BF Dropdowns
    
    public List<string> ShutoffValveOptions { get; } =
    [
        "BOTH OK", "BOTH CLOSED", "BOTH VALVES",
        "#1 VALVE", "#2 VALVE"
    ];
    
    #endregion
    
    #region PVB Related Properties
    
    public List<string> BackPressureOptions { get; } =
    [
        "NO", "YES"
    ];
    
    #endregion
    
    #endregion
    
    #region Private properties

    #region All BF Properties

    private string? _linePressure;
    private string? _shutoffValve;
    private string? _sovComment;

    #endregion
    
    #region Check Related Properties
    
    private string? _checkValve1;
    private string? _checkValve2;
    private bool _checkValve1Leaked;
    private bool _checkValve2Leaked;
    
    #endregion
    
    #region RV Related Properties
    
    private string? _pressureReliefOpening;
    private bool _reliefValveDidNotOpen;
    private bool _reliefValveLeaking;

    #endregion
    
    #region PVB Related Properties
    
    private string? _backPressure;
    private string? _airInletOpening;
    private bool _airInletLeaked;
    private bool _airInletDidNotOpen;
    private string? _ckPvb;
    private bool _ckPvbLeaked;

    #endregion
    
    #region BaseTestViewModel
    
    private Dictionary<string, string> _failedFieldsToSave = new Dictionary<string, string>();
    private Dictionary<string, string> _passedFieldsToSave = new Dictionary<string, string>();
    
    #endregion
    
    #endregion
    
    #region Public Properties

    #region All BF Properties
    
    public string? LinePressure
    {
        get => _linePressure;
        set
        {
            _linePressure = value;
            _failedFieldsToSave["LinePressure"] = value ?? string.Empty;
            _passedFieldsToSave["LinePressure"] = value ?? string.Empty;
            OnPropertyChanged(nameof(LinePressure));
        }
    }
    
    public string? ShutoffValve
    {
        get => _shutoffValve;
        set
        {
            _shutoffValve = value;
            _failedFieldsToSave["SOVList"] = value ?? string.Empty;
            _passedFieldsToSave["SOVList"] = value ?? string.Empty;
            OnPropertyChanged(nameof(ShutoffValve));
        }
    }
    
    public string? SovComment
    {
        get => _sovComment;
        set
        {
            _sovComment = value;
            _failedFieldsToSave["SOVComment"] = value?.ToUpper() ?? string.Empty;
            _passedFieldsToSave["SOVComment"] = value?.ToUpper() ?? string.Empty;
            OnPropertyChanged(nameof(SovComment));
        }
    }

    #endregion
    
    #region Check Related Properties
    public string? CheckValve1
    {
        get => _checkValve1;
        set
        {
            _checkValve1 = value;
            _failedFieldsToSave["InitialCT1"] = decimal.TryParse(CheckValve1, out decimal fcv1) ? fcv1.ToString("F1") : string.Empty;
            _passedFieldsToSave["FinalCT1"] = decimal.TryParse(CheckValve1, out decimal pcv1) ? pcv1.ToString("F1") : string.Empty;
            OnPropertyChanged(nameof(CheckValve1));
        }
    }

    public string? CheckValve2
    {
        get => _checkValve2;
        set
        {
            _checkValve2 = value;
            _failedFieldsToSave["InitialCT2"] = decimal.TryParse(CheckValve2, out decimal fcv2) ? fcv2.ToString("F1") : string.Empty;
            _passedFieldsToSave["FinalCT2"] = decimal.TryParse(CheckValve2, out decimal pcv2) ? pcv2.ToString("F1") : string.Empty;
            OnPropertyChanged(nameof(CheckValve2));
        }
    }
    
    public bool CheckValve1Leaked
    {
        get => _checkValve1Leaked;
        set
        {
            _checkValve1Leaked = value;
            _failedFieldsToSave["InitialCTBox"] = value ? "Off" : "On";
            _failedFieldsToSave["InitialCT1Leaked"] = value ? "On" : "Off";
            _passedFieldsToSave["FinalCT1Box"] = value ? "Off" : "On";
            OnPropertyChanged(nameof(CheckValve1Leaked));
        }
    }

    public bool CheckValve2Leaked
    {
        get => _checkValve2Leaked;
        set
        {
            _checkValve2Leaked = value;
            _failedFieldsToSave["InitialCT2Box"] = value ? "Off" : "On";
            _failedFieldsToSave["InitialCT2Leaked"] = value ? "On" : "Off";
            _passedFieldsToSave["FinalCT2Box"] = value ? "Off" : "On";
            OnPropertyChanged(nameof(CheckValve2Leaked));
        }
    }

    #endregion
    
    #region RV Related Properties
    
    public string? PressureReliefOpening
    {
        get => _pressureReliefOpening;
        set
        {
            _pressureReliefOpening = value;
            _failedFieldsToSave["InitialPSIRV"] = decimal.TryParse(PressureReliefOpening, out decimal frv) ? frv.ToString("F1") : string.Empty;
            _passedFieldsToSave["FinalRV"] = decimal.TryParse(PressureReliefOpening, out decimal prv) ? prv.ToString("F1") : string.Empty;
            OnPropertyChanged(nameof(_pressureReliefOpening));
        }
    }
    
    public bool ReliefValveDidNotOpen
    {
        get => _reliefValveDidNotOpen;
        set
        {
            _reliefValveDidNotOpen = value;
            _failedFieldsToSave["InitialRVDidNotOpen"] = ReliefValveDidNotOpen ? "On" : "Off";
            OnPropertyChanged(nameof(ReliefValveDidNotOpen));
        }
    }
    
    public bool ReliefValveLeaking
    {
        get => _reliefValveLeaking;
        set
        {
            _reliefValveLeaking = value;
            OnPropertyChanged(nameof(ReliefValveLeaking));
        }
    }

    #endregion
    
    #region PVB Related Properties
    
    public string? BackPressure
    {
        get => _backPressure;
        set
        {
            _backPressure = value;
            _failedFieldsToSave["BackPressure"] = value ?? string.Empty;
            _passedFieldsToSave["BackPressure"] = value ?? string.Empty;
            OnPropertyChanged(nameof(BackPressure));
        }
    }
    
    public string? AirInletOpening
    {
        get => _airInletOpening;
        set
        {
            _airInletOpening = value;
            _failedFieldsToSave["InitialAirInlet"] = decimal.TryParse(AirInletOpening, out decimal fai) ? fai.ToString("F1") : string.Empty;
            _passedFieldsToSave["FinalAirInlet"] = decimal.TryParse(AirInletOpening, out decimal pai) ? pai.ToString("F1") : string.Empty;
            OnPropertyChanged(nameof(_airInletOpening));
        }
    }
    
    public bool AirInletLeaked
    {
        get => _airInletLeaked;
        set
        {
            _airInletLeaked = value;
            _failedFieldsToSave["InitialAirInletLeaked"] = AirInletLeaked ? "On" : "Off";
            OnPropertyChanged(nameof(AirInletLeaked));
        }
    }
    
    public bool AirInletDidNotOpen
    {
        get => _airInletDidNotOpen;
        set
        {
            _airInletDidNotOpen = value;
            _failedFieldsToSave["InitialCkPVBLDidNotOpen"] = AirInletDidNotOpen ? "On" : "Off";
            OnPropertyChanged(nameof(AirInletDidNotOpen));
        }
    }
    
    public string? CkPvb
    {
        get => _ckPvb;
        set
        {
            _ckPvb = value;
            _failedFieldsToSave["InitialCk1PVB"] = decimal.TryParse(CkPvb, out decimal fai) ? fai.ToString("F1") : string.Empty;
            _passedFieldsToSave["Check Valve"] = decimal.TryParse(CkPvb, out decimal pai) ? pai.ToString("F1") : string.Empty;
            OnPropertyChanged(nameof(CkPvb));
        }
    }

    
    public bool CkPvbLeaked
    {
        get => _ckPvbLeaked;
        set
        {
            _ckPvbLeaked = value;
            _failedFieldsToSave["InitialCkPVBLeaked"] = CkPvbLeaked ? "On" : "Off";
            OnPropertyChanged(nameof(CkPvbLeaked));
        }
    }
    
    #endregion
    
    #endregion

    #region Functions
    
    # region Implementations
    protected override void LoadFormFields(Dictionary<string, string> formFields)
    {
        // Init check valve leaked buttons as true
        var type = FormData?.GetValueOrDefault("BFType");
        switch (type)
        {
            case "RP":
                CheckValve1Leaked = true;
                CheckValve2Leaked = true;
                break;
            case "DC":
                CheckValve1Leaked = true;
                CheckValve2Leaked = true;
                break;
            case "SC":
                CheckValve1Leaked = true;
                break;
            default:
                break;
        }
    }

    protected override async Task OnNext()
    {
        if (!await ValidateFields()) return;
        if (IsBackflowPassing())
        {
            await HandlePassingTest();
        }
        else
        {
            await HandleFailingTest();
        }
    }

    private async Task HandlePassingTest()
    {
        // Save Form Data
        SaveFormData(_passedFieldsToSave);
        
        // Check if previously failed
        var ck1 = FormData?.GetValueOrDefault("InitialCT1");
        var airInlet = FormData?.GetValueOrDefault("InitialAirInlet");
        var viewModel = new PassFinalViewModel(false, false, false);
        
        if (!string.IsNullOrEmpty(ck1) || !string.IsNullOrEmpty(airInlet))
        {
            viewModel = new PassFinalViewModel(true, true, true);
        }
        else
        {
            viewModel = new PassFinalViewModel(false, false, true);
        }
        
        // Load 'PassFinalViewModel'
        viewModel.LoadPdfData(PdfData ?? throw new InvalidOperationException(),
            FormData ?? throw new InvalidOperationException());
        
        await Shell.Current.GoToAsync("PassFinal", new Dictionary<string, object>
        {
            { "ViewModel", viewModel }
        });
    }

    private async Task HandleFailingTest()
    {
        // Special Case For Leaking RVs
        if (ReliefValveLeaking)
        {
            if (_failedFieldsToSave.TryGetValue("InitialPSIRV", out string curStr))
            {
                if (!curStr.StartsWith("LEAKING"))
                {
                    _failedFieldsToSave["InitialPSIRV"] = "LEAKING/" + curStr;
                }
            }
            else
            {
                _failedFieldsToSave["InitialPSIRV"] = "LEAKING";
            }
        }
        
        // Save Form Data
        SaveFormData(_failedFieldsToSave);
        
        // Create 'RepairViewModel'
        var repairViewModel = new BaseRepairViewModel();
        repairViewModel.LoadPdfData(PdfData ?? throw new InvalidOperationException(),
            FormData ?? throw new InvalidOperationException());
        
        // Load 'RepairViewModel' Based On Type
        var type = FormData?.GetValueOrDefault("BFType");
        if (string.IsNullOrEmpty(type)) throw new InvalidDataException();
        
        switch (type)
        {
            case "RP":
                await Shell.Current.GoToAsync("RpRepair", new Dictionary<string, object>
                {
                    { "ViewModel", repairViewModel }
                });
                break;
            case "DC":
                await Shell.Current.GoToAsync("DcRepair", new Dictionary<string, object>
                {
                    { "ViewModel", repairViewModel }
                });
                break;
            case "SC":
                await Shell.Current.GoToAsync("ScRepair", new Dictionary<string, object>
                {
                    { "ViewModel", repairViewModel }
                });
                break;
            case "PVB":
                await Shell.Current.GoToAsync("PvbRepair", new Dictionary<string, object>
                {
                    { "ViewModel", repairViewModel }
                });
                break;
            case "SVB":
                await Shell.Current.GoToAsync("SvbRepair", new Dictionary<string, object>
                {
                    { "ViewModel", repairViewModel }
                });
                break;
            default:
                await Application.Current.MainPage.DisplayAlert(
                    "Not Implemented",
                    $"The type '{type}' has not been implemented.",
                    "OK"
                );
                break;
        }
    }

    #endregion
    
    # region Abstract

    protected virtual async Task<bool> ValidateFields()
    {
        if (!await AreFieldsValid(new (string Value, string Name)[]
            {
                (LinePressure ?? "", "Line Pressure"),
                (ShutoffValve ?? "", "Shutoff Valve"),
            })) return false;
        
        return true;
    }

    // TODO: Add shut off valve #2 checkstate
    protected abstract bool IsBackflowPassing();

    #endregion

    #endregion

}