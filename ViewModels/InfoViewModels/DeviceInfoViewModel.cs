﻿using ABFReportEditor.ViewModels.TestViewModels;

namespace ABFReportEditor.ViewModels.InfoViewModels;

public class DeviceInfoViewModel : BaseBackflowViewModel
{
    #region Dropdown Items
    
    public List<string> InstallationStatusOptions { get; } =
        ["NEW", "EXISTING", "REPLACEMENT"];

    public List<String> ProtectionTypeOptions { get; } =
        ["SECONDARY / CONTAINMENT", "PRIMARY / POINT OF USE"];

    public List<String> ServiceTypeOptions { get; } =
        ["DOMESTIC", "IRRIGATION", "FIRE"];

    public List<string> ManufacturerOptions { get; } =
    [
        "WATTS", "WILKINS", "FEBCO", "AMES", "ARI", "APOLLO",
        "CONBRACO", "HERSEY", "FLOMATIC", "BACKFLOW DIRECT"
    ];

    public List<string> TypeOptions { get; } =
        ["RP", "DC", "PVB", "SVB", "SC", "TYPE 2"];

    #endregion
    
    #region Private Properties

    private string? _waterPurveyor;
    private string? _assemblyAddress;
    private string? _onSiteLocation;
    private string? _primaryService;
    private string? _installationStatus;
    private string? _protectionType;
    private string? _serviceType;
    private string? _waterMeterNo;
    private string? _serialNo;
    private string? _modelNo;
    private string? _size;
    private string? _manufacturer;
    private string? _type;

    #endregion
    
    #region Public Properties
    
    public string? WaterPurveyor
    {
        get => _waterPurveyor;
        set
        {
            _waterPurveyor = value;
            OnPropertyChanged(nameof(WaterPurveyor));
        }
    }

    public string? AssemblyAddress
    {
        get => _assemblyAddress;
        set
        {
            _assemblyAddress = value;
            OnPropertyChanged(nameof(AssemblyAddress));
        }
    }

    public string? OnSiteLocation
    {
        get => _onSiteLocation;
        set
        {
            _onSiteLocation = value;
            OnPropertyChanged(nameof(OnSiteLocation));
        }
    }

    public string? PrimaryService
    {
        get => _primaryService;
        set
        {
            _primaryService = value;
            OnPropertyChanged(nameof(PrimaryService));
        }
    }

    public string? InstallationStatus
    {
        get => _installationStatus;
        set
        {
            _installationStatus = value;
            OnPropertyChanged(nameof(InstallationStatus));
        }
    }

    public string? ServiceType
    {
        get => _serviceType;
        set
        {
            _serviceType = value;
            OnPropertyChanged(nameof(ServiceType));
        }
    }

    public string? ProtectionType
    {
        get => _protectionType;
        set
        {
            _protectionType = value;
            OnPropertyChanged(nameof(ProtectionType));
        }
    }

    public string? WaterMeterNo
    {
        get => _waterMeterNo;
        set
        {
            _waterMeterNo = value;
            OnPropertyChanged(nameof(WaterMeterNo));
        }
    }

    public string? SerialNo
    {
        get => _serialNo;
        set
        {
            _serialNo = value;
            OnPropertyChanged(nameof(SerialNo));
        }
    }

    public string? ModelNo
    {
        get => _modelNo;
        set
        {
            _modelNo = value;
            OnPropertyChanged(nameof(ModelNo));
        }
    }

    public string? Size
    {
        get => _size;
        set
        {
            _size = value;
            OnPropertyChanged(nameof(Size));
        }
    }

    public string? Manufacturer
    {
        get => _manufacturer;
        set
        {
            _manufacturer = value;
            OnPropertyChanged(nameof(Manufacturer));
        }
    }

    public string? Type
    {
        get => _type;
        set
        {
            _type = value;
            OnPropertyChanged(nameof(Type));
        }
    }

    #endregion
    
    #region Abstract Methods
    
    protected override void LoadFormFields(Dictionary<string, string> formFields)
    {
        WaterPurveyor = formFields.GetValueOrDefault("WaterPurveyor");
        AssemblyAddress = formFields.GetValueOrDefault("AssemblyAddress");
        OnSiteLocation = formFields.GetValueOrDefault("On Site Location of Assembly");
        PrimaryService = formFields.GetValueOrDefault("PrimaryBusinessService");
        InstallationStatus = formFields.GetValueOrDefault("InstallationIs");
        ProtectionType = formFields.GetValueOrDefault("ProtectionType");
        ServiceType = formFields.GetValueOrDefault("ServiceType");
        WaterMeterNo = formFields.GetValueOrDefault("WaterMeterNo");
        SerialNo = formFields.GetValueOrDefault("SerialNo");
        ModelNo = formFields.GetValueOrDefault("ModelNo");
        Size = formFields.GetValueOrDefault("Size");
        Manufacturer = formFields.GetValueOrDefault("Manufacturer");
        Type = formFields.GetValueOrDefault("BFType");
    }

    protected override async Task OnNext()
    {
        // Check if the necessary fields were filled
        if (Type == null) return;
        
        // Save form fields to form data
        Dictionary<string, string> formFields = new Dictionary<string, string>()
        {
            { "WaterPurveyor", WaterPurveyor ?? String.Empty },
            { "AssemblyAddress", AssemblyAddress ?? String.Empty },
            { "On Site Location of Assembly", OnSiteLocation ?? String.Empty },
            { "PrimaryBusinessService", PrimaryService ?? String.Empty },
            { "InstallationIs", InstallationStatus ?? String.Empty },
            { "ProtectionType", ProtectionType ?? String.Empty },
            { "ServiceType", ServiceType ?? String.Empty },
            { "WaterMeterNo", WaterMeterNo ?? String.Empty },
            { "SerialNo", SerialNo ?? String.Empty },
            { "ModelNo", ModelNo ?? String.Empty },
            { "Size", Size ?? String.Empty },
            { "Manufacturer", Manufacturer ?? String.Empty },
            { "BFType", Type ?? String.Empty }
        };
        SaveFormData(formFields);
        
        // Load next viewmodel
        switch (Type)
        {
            case "RP":
                var viewModel = new RpTestViewModel();
                viewModel.LoadPdfData(PdfData ?? throw new InvalidOperationException(),
                    FormData ?? throw new InvalidOperationException());
                await Shell.Current.GoToAsync("RpTest", new Dictionary<string, object>
                {
                    { "ViewModel", viewModel }
                });
                break;
            case "DC":
                await Shell.Current.GoToAsync("DcTest");
                break;
            case "PVB":
                await Shell.Current.GoToAsync("PvbTest");
                break;
            case "SVB":
                await Application.Current.MainPage.DisplayAlert(
                    "Not Implemented",
                    $"The type '{Type}' has not been implemented.",
                    "OK"
                );
                break;
            case "SC":
                await Application.Current.MainPage.DisplayAlert(
                    "Not Implemented",
                    $"The type '{Type}' has not been implemented yet.",
                    "OK"
                );
                break;
            case "TYPE 2":
                await Application.Current.MainPage.DisplayAlert(
                    "Not Implemented",
                    $"The type '{Type}' has not been implemented.",
                    "OK"
                );
                break;
            default:
                await Application.Current.MainPage.DisplayAlert(
                    "Not Implemented",
                    $"The type '{Type}' has not been implemented.",
                    "OK"
                );
                break;
        }
    }
    
    #endregion
}