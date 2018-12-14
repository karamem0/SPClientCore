---
external help file: SPClientCore.dll-Help.xml
Module Name: SPClientCore
online version:
schema: 2.0.0
---

# Remove-KshListItem

## SYNOPSIS
Removes a list item.

## SYNTAX

### ParamSet1
```
Remove-KshListItem [-Identity] <ListItem> [<CommonParameters>]
```

### ParamSet2
```
Remove-KshListItem [-Identity] <ListItem> [-Force] [<CommonParameters>]
```

## DESCRIPTION
The Remove-KshListItem cmdlet removes a list item from the parent list.

## EXAMPLES

### Example 1
```powershell
PS C:\> $list = Get-KshList -ListTitle 'Announcements'
PS C:\> $listItem = Get-KshListItem -List $list -ItemId 1
PS C:\> $guid = Remove-KshListItem -Identity $listItem
```

Moves a list item to the recycle bin.

### Example 2
```powershell
PS C:\> $list = Get-KshList -ListTitle 'Announcements'
PS C:\> $listItem = Get-KshListItem -List $list -ItemId 1
PS C:\> Remove-KshListItem -Identity $listItem -Force
```

Removes a list item permanently.

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
Specifies the list item.

```yaml
Type: ListItem
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