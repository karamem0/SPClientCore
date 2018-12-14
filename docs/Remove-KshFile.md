---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshFile

## SYNOPSIS
Removes a file.

## SYNTAX

### ParamSet1
```
Remove-KshFile [-Identity] <File> [<CommonParameters>]
```

### ParamSet2
```
Remove-KshFile [-Identity] <File> [-Force] [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshFile cmdlet removes a file from the parent folder.

## EXAMPLES

### Example 1
```powershell
PS C:\> $file = Get-KshFile -FileUrl '/sites/japan/hr/Shared%20Documents/Readme.txt'
PS C:\> $guid = Remove-KshFile -Identity $file
```

Moves a file to the recycle bin.

### Example 2
```powershell
PS C:\> $file = Get-KshFile -FileUrl '/sites/japan/hr/Shared%20Documents/Readme.txt'
PS C:\> Remove-KshFile -Identity $file -Force
```

Removes a file permanently.

## PARAMETERS

### -Force
If specified, removes object permanently.

```yaml
Type: SwitchParameter
Parameter Sets: ParamSet2
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
Specifies the file.

```yaml
Type: File
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Karamem0.SharePoint.PowerShell.Models.File

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS