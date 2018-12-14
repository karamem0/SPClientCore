---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshRecycleBinItem

## SYNOPSIS
Removes a recycle bin item.

## SYNTAX

### ParamSet1
```
Remove-KshRecycleBinItem [-Identity] <RecycleBinItem> [<CommonParameters>]
```

### ParamSet2
```
Remove-KshRecycleBinItem [-All] [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshListItem cmdlet removes a recycle bin item from the current site.

## EXAMPLES

### Example 1
```powershell
PS C:\> $recycleBinItem = Get-KshRecycleBinItem -ItemId '77566246-6e0d-4bc7-8360-689b8743265f'
PS C:\> Remove-KshRecycleBinItem -Identity $recycleBinItem
```

Removes a recycle bin item.

### Example 2
```powershell
PS C:\> Remove-KshRecycleBinItem -All
```

Removes all recycle bin items.

## PARAMETERS

### -All
If specified, removes all recycle bin items.

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
Specifies the recycle bin item.

```yaml
Type: RecycleBinItem
Parameter Sets: ParamSet1
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

### Karamem0.SharePoint.PowerShell.Models.RecycleBinItem

## OUTPUTS

### System.Void

## NOTES

## RELATED LINKS