---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshList

## SYNOPSIS
Removes a list.

## SYNTAX

### ParamSet1
```
Remove-KshList [-Identity] <List> [<CommonParameters>]
```

### ParamSet2
```
Remove-KshList [-Identity] <List> [-Force] [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshList cmdlet removes a list from the current site.

## EXAMPLES

### Example 1
```powershell
PS C:\> $list = Get-KshList -ListTitle 'Announcements'
PS C:\> $guid = Remove-KshList -Identity $list
```

Moves a list to the recycle bin.

### Example 2
```powershell
PS C:\> $list = Get-KshList -ListTitle 'Announcements'
PS C:\> Remove-KshList -Identity $list -Force
```

Removes a list permanently.

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
Specifies the list.

```yaml
Type: List
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

### Karamem0.SharePoint.PowerShell.Models.List

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS