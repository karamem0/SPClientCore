#
# Copyright (c) 2019 karamem0
#
# This software is released under the MIT License.
#
# https://github.com/karamem0/SPClientCore/blob/master/LICENSE
#

function Install-TestSite {

    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [uri]
        $Url,
        [Parameter(Mandatory = $true)]
        [string]
        $UserName,
        [Parameter(Mandatory = $true)]
        [string]
        $Password,
        [Parameter(Mandatory = $true)]
        [string]
        $DomainName
    )

    process {
        $appSettings = [ordered]@{ }

        $authorityUrl = $Url.GetLeftPart([System.UriPartial]::Authority)
        $adminUrl = $authorityUrl.Replace('.sharepoint.com', '-admin.sharepoint.com')

        $credential = New-Object System.Net.NetworkCredential("$UserName@$DomainName", $Password)
        $credential = New-Object System.Management.Automation.PSCredential($credential.UserName, $credential.SecurePassword)

        $appSettings.LoginDomainName = $DomainName
        $appSettings.LoginUserName = "$UserName@$DomainName"
        $appSettings.LoginPassword = $Password
        $appSettings.BaseUrl = $Url
        $appSettings.AuthorityUrl = $authorityUrl
        $appSettings.AdminUrl = $adminUrl

        Write-Progress -Activity 'Sign in...' -Status 'Processing'
        Connect-KshSite -Url $adminUrl -Credential $credential

        Write-Progress -Activity 'Creating site collection...' -Status 'Processing'
        $siteCollection = New-KshTenantSiteCollection `
            -Lcid 1033 `
            -Owner $credential.UserName `
            -StorageMaxLevel 26214400 `
            -Title 'SPClientCore' `
            -Url $Url

        Write-Progress -Activity 'Sign in...' -Status 'Processing'
        Connect-KshSite -Url $Url -Credential $credential

        Write-Progress -Activity 'Retrieving a site collection....' -Status 'Processing'
        $siteCollection = Get-KshCurrentSiteCollection
        $appSettings.SiteCollectionGuid = $siteCollection.Id
        $appSettings.SiteCollectionUrl = $siteCollection.ServerRelativeUrl

        Write-Progress -Activity 'Removing existing groups...' -Status 'Processing'
        Get-KshGroup | Remove-KshGroup

        Write-Progress -Activity 'Creating site groups...' -Status 'Test Group 1'
        $group1 = New-KshGroup `
            -Description 'Test Group 1' `
            -Title 'Test Group 1'
        Set-KshGroupOwner `
            -Group $group1 `
            -Owner $group1
        $appSettings.Group1Id = $group1.Id
        $appSettings.Group1Name = $group1.Title

        Write-Progress -Activity 'Creating site groups...' -Status 'Test Group 2'
        $group2 = New-KshGroup `
            -Description 'Test Group 2' `
            -Title 'Test Group 2'
        Set-KshGroupOwner `
            -Group $group2 `
            -Owner $group2
        $appSettings.Group2Id = $group2.Id
        $appSettings.Group2Name = $group2.Title

        Write-Progress -Activity 'Creating site groups...' -Status 'Test Group 3'
        $group3 = New-KshGroup `
            -Description 'Test Group 3' `
            -Title 'Test Group 3'
        Set-KshGroupOwner `
            -Group $group3 `
            -Owner $group3
        $appSettings.Group3Id = $group3.Id
        $appSettings.Group3Name = $group3.Title

        Write-Progress -Activity 'Creating site users...' -Status 'Test User 1'
        $user1 = New-KshUser `
            -Email "testuser1@$DomainName" `
            -LoginName "i:0#.f|membership|testuser1@$DomainName" `
            -Title 'Test User 1'
        Add-KshGroupMember `
            -Group $group1 `
            -Member $user1
        $appSettings.User1Id = $user1.Id
        $appSettings.User1LoginName = $user1.LoginName
        $appSettings.User1Title = $user1.Title
        $appSettings.User1Email = $user1.Email

        Write-Progress -Activity 'Creating site users...' -Status 'Test User 2'
        $user2 = New-KshUser `
            -Email "testuser2@$DomainName" `
            -LoginName "i:0#.f|membership|testuser2@$DomainName" `
            -Title 'Test User 2'
        Add-KshGroupMember `
            -Group $group1 `
            -Member $user2
        $appSettings.User2Id = $user2.Id
        $appSettings.User2LoginName = $user2.LoginName
        $appSettings.User2Title = $user2.Title
        $appSettings.User2Email = $user2.Email

        Write-Progress -Activity 'Creating site users...' -Status 'Test User 3'
        $user3 = New-KshUser `
            -Email "testuser3@$DomainName" `
            -LoginName "i:0#.f|membership|testuser3@$DomainName" `
            -Title 'Test User 3'
        Add-KshGroupMember `
            -Group $group1 `
            -Member $user3
        $appSettings.User3Id = $user3.Id
        $appSettings.User3LoginName = $user3.LoginName
        $appSettings.User3Title = $user3.Title
        $appSettings.User3Email = $user3.Email

        Write-Progress -Activity 'Creating sites...' -Status 'Test Site 1'
        $site1 = New-KshSite `
            -Description 'Test Site 1' `
            -Lcid 1033 `
            -ServerRelativeUrl 'TestSite1' `
            -Template 'STS#1' `
            -Title 'Test Site 1'
        $appSettings.Site1Id = $site1.Id
        $appSettings.Site1Url = $site1.ServerRelativeUrl
        $appSettings.Site1Title = $site1.Title

        Write-Progress -Activity 'Changing current site...' -Status 'Test Site 1'
        Select-KshSite -Identity $site1

        Write-Progress -Activity 'Creating sites...' -Status 'Test Site 2'
        $site2 = New-KshSite `
            -Description 'Test Site 2' `
            -Lcid 1033 `
            -ServerRelativeUrl 'TestSite2' `
            -Template 'STS#1' `
            -Title 'Test Site 2'
        $appSettings.Site2Id = $site2.Id
        $appSettings.Site2Url = $site2.ServerRelativeUrl
        $appSettings.Site2Title = $site2.Title

        Write-Progress -Activity 'Creating sites...' -Status 'Test Site 3'
        $site3 = New-KshSite `
            -Description 'Test Site 3' `
            -Lcid 1033 `
            -ServerRelativeUrl 'TestSite3' `
            -Template 'STS#1' `
            -Title 'Test Site 3'
        $appSettings.Site3Id = $site3.Id
        $appSettings.Site3Url = $site3.ServerRelativeUrl
        $appSettings.Site3Title = $site3.Title

        Write-Progress -Activity 'Changing current site...' -Status 'Test Site 2'
        Select-KshSite -Identity $site2

        Write-Progress -Activity 'Creating sites...' -Status 'Test Site 4'
        $site4 = New-KshSite `
            -Description 'Test Site 4' `
            -Lcid 1033 `
            -ServerRelativeUrl 'TestSite4' `
            -Template 'STS#1' `
            -Title 'Test Site 4'
        $appSettings.Site4Id = $site4.Id
        $appSettings.Site4Url = $site4.ServerRelativeUrl
        $appSettings.Site4Title = $site4.Title

        Write-Progress -Activity 'Changing current site...' -Status 'Test Site 1'
        Select-KshSite -Identity $site1

        Write-Progress -Activity 'Creating lists...' -Status 'Test List 1'
        $list1 = New-KshList `
            -Description 'Test List 1' `
            -ServerRelativeUrl 'Lists/TestList1' `
            -Template 100 `
            -Title 'Test List 1'
        $list1 = Update-KshList `
            -Identity $list1 `
            -ContentTypesEnabled $true `
            -DraftVersionVisibility 1 `
            -EnableModeration $true `
            -EnableVersioning $true `
            -PassThru
        $rootFolder1 = Get-KshFolder -List $list1
        $appSettings.List1Id = $list1.Id
        $appSettings.List1Title = $list1.Title
        $appSettings.List1Url = $rootFolder1.ServerRelativeUrl

        Write-Progress -Activity 'Creating lists...' -Status 'Test List 2'
        $list2 = New-KshList `
            -Description 'Test List 2' `
            -ServerRelativeUrl 'TestList2' `
            -Template 101 `
            -Title 'Test List 2'
        $list2 = Update-KshList `
            -Identity $list2 `
            -ContentTypesEnabled $true `
            -DraftVersionVisibility 1 `
            -EnableMinorVersions $true `
            -EnableModeration $true `
            -EnableVersioning $true `
            -PassThru
        $rootFolder2 = Get-KshFolder -List $list2
        $appSettings.List2Id = $list2.Id
        $appSettings.List2Title = $list2.Title
        $appSettings.List2Url = $rootFolder2.ServerRelativeUrl

        Write-Progress -Activity 'Creating lists...' -Status 'Test List 3'
        $list3 = New-KshList `
            -Description 'Test List 3' `
            -ServerRelativeUrl 'Lists/TestList33' `
            -Template 101 `
            -Title 'Test List 3'
        $rootFolder3 = Get-KshFolder -List $list3
        $appSettings.List3Id = $list3.Id
        $appSettings.List3Title = $list3.Title
        $appSettings.List3Url = $rootFolder3.ServerRelativeUrl

        Write-Progress -Activity 'Creating site content types...' -Status 'Test Content Type 1'
        $siteContentType1 = New-KshContentType `
            -Description 'Test Content Type 1' `
            -Group 'Test Content Type Group' `
            -Name 'Test Content Type 1'
        $appSettings.SiteContentType1Id = $siteContentType1.StringId

        Write-Progress -Activity 'Creating site content types...' -Status 'Test Content Type 2'
        $siteContentType2 = New-KshContentType `
            -Description 'Test Content Type 2' `
            -Group 'Test Content Type Group' `
            -Name 'Test Content Type 2'
        $appSettings.SiteContentType2Id = $siteContentType2.StringId

        Write-Progress -Activity 'Creating site content types...' -Status 'Test Content Type 3'
        $siteContentType3 = New-KshContentType `
            -Description 'Test Content Type 3' `
            -Group 'Test Content Type Group' `
            -Name 'Test Content Type 3'
        $appSettings.SiteContentType3Id = $siteContentType3.StringId

        Write-Progress -Activity 'Creating site content types...' -Status 'Test Content Type 4'
        $siteContentType4 = New-KshContentType `
            -Description 'Test Content Type 4' `
            -Group 'Test Content Type Group' `
            -Name 'Test Content Type 4'
        $appSettings.SiteContentType4Id = $siteContentType4.StringId

        Write-Progress -Activity 'Creating site content types...' -Status 'Test Content Type 5'
        $siteContentType5 = New-KshContentType `
            -Description 'Test Content Type 5' `
            -Group 'Test Content Type Group' `
            -Name 'Test Content Type 5'
        $appSettings.SiteContentType5Id = $siteContentType5.StringId

        Write-Progress -Activity 'Creating site content types...' -Status 'Test Content Type 6'
        $siteContentType6 = New-KshContentType `
            -Description 'Test Content Type 6' `
            -Group 'Test Content Type Group' `
            -Name 'Test Content Type 6'
        $appSettings.SiteContentType6Id = $siteContentType6.StringId

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 1'
        $column1 = New-KshColumnText `
            -AddColumnOptions 8 `
            -Name 'TestColumn1' `
            -Title 'Test Column 1'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column1
        $appSettings.Column1Id = $column1.Id
        $appSettings.Column1Name = $column1.Name
        $appSettings.Column1Title = $column1.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 2'
        $column2 = New-KshColumnMultiLineText `
            -AddColumnOptions 8 `
            -Name 'TestColumn2' `
            -Title 'Test Column 2'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column2
        $appSettings.Column2Id = $column2.Id
        $appSettings.Column2Name = $column2.Name
        $appSettings.Column2Title = $column2.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 3'
        $column3 = New-KshColumnChoice `
            -AddColumnOptions 8 `
            -Choices @('Test Value 1', 'Test Value 2', 'Test Value 3') `
            -Name 'TestColumn3' `
            -Title 'Test Column 3'
        $null = New-KshContentTypeColumn ` `
            -ContentType $siteContentType1 `
            -Column $column3
        $appSettings.Column3Id = $column3.Id
        $appSettings.Column3Name = $column3.Name
        $appSettings.Column3Title = $column3.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 4'
        $column4 = New-KshColumnMultiChoice `
            -AddColumnOptions 8 `
            -Choices @('Test Value 1', 'Test Value 2', 'Test Value 3') `
            -Name 'TestColumn4' `
            -Title 'Test Column 4'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column4
        $appSettings.Column4Id = $column4.Id
        $appSettings.Column4Name = $column4.Name
        $appSettings.Column4Title = $column4.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 5'
        $column5 = New-KshColumnNumber `
            -AddColumnOptions 8 `
            -Name 'TestColumn5' `
            -Title 'Test Column 5'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column5
        $appSettings.Column5Id = $column5.Id
        $appSettings.Column5Name = $column5.Name
        $appSettings.Column5Title = $column5.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 6'
        $column6 = New-KshColumnCurrency `
            -AddColumnOptions 8 `
            -Name 'TestColumn6' `
            -Title 'Test Column 6'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column6
        $appSettings.Column6Id = $column6.Id
        $appSettings.Column6Name = $column6.Name
        $appSettings.Column6Title = $column6.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 7'
        $column7 = New-KshColumnDateTime `
            -AddColumnOptions 8 `
            -Name 'TestColumn7' `
            -Title 'Test Column 7'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column7
        $appSettings.Column7Id = $column7.Id
        $appSettings.Column7Name = $column7.Name
        $appSettings.Column7Title = $column7.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 8'
        $column8 = New-KshColumnLookup `
            -AddColumnOptions 8 `
            -LookupColumnName 'Title' `
            -LookupListId $list1.Id `
            -Name 'TestColumn8' `
            -Title 'Test Column 8'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column8
        $appSettings.Column8Id = $column8.Id
        $appSettings.Column8Name = $column8.Name
        $appSettings.Column8Title = $column8.Title

        Write-Progress -Activity 'Creating columns...' -Status 'Test Column 9'
        $column9 = New-KshColumnLookup `
            -AddColumnOptions 8 `
            -AllowMultipleValues $true `
            -LookupColumnName 'Title' `
            -LookupListId $list1.Id `
            -Name 'TestColumn9' `
            -Title 'Test Column 9'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column9
        $appSettings.Column9Id = $column9.Id
        $appSettings.Column9Name = $column9.Name
        $appSettings.Column9Title = $column9.Title

        Write-Progress -Activity 'Creating fields...' -Status 'Test Column 10'
        $column10 = New-KshColumnBoolean `
            -AddColumnOptions 8 `
            -Name 'TestColumn10' `
            -Title 'Test Column 10'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column10
        $appSettings.Column10Id = $column10.Id
        $appSettings.Column10Name = $column10.Name
        $appSettings.Column10Title = $column10.Title

        Write-Progress -Activity 'Creating fields...' -Status 'Test Column 11'
        $column11 = New-KshColumnUser `
            -AddColumnOptions 8 `
            -Name 'TestColumn11' `
            -Title 'Test Column 11'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column11
        $appSettings.Column11Id = $column11.Id
        $appSettings.Column11Name = $column11.Name
        $appSettings.Column11Title = $column11.Title

        Write-Progress -Activity 'Creating fields...' -Status 'Test Column 12'
        $column12 = New-KshColumnUser `
            -AddColumnOptions 8 `
            -AllowMultipleValues $true `
            -Name 'TestColumn12' `
            -Title 'Test Column 12'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column12
        $appSettings.Column12Id = $column12.Id
        $appSettings.Column12Name = $column12.Name
        $appSettings.Column12Title = $column12.Title

        Write-Progress -Activity 'Creating fields...' -Status 'Test Column 13'
        $column13 = New-KshColumnUrl `
            -AddColumnOptions 8 `
            -Name 'TestColumn13' `
            -Title 'Test Column 13'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column13
        $appSettings.Column13Id = $column13.Id
        $appSettings.Column13Name = $column13.Name
        $appSettings.Column13Title = $column13.Title

        Write-Progress -Activity 'Creating fields...' -Status 'Test Column 14'
        $column14 = New-KshColumnCalculated `
            -AddColumnOptions 8 `
            -Columns @($column1) `
            -Formula '=TestColumn1' `
            -Name 'TestColumn14' `
            -OutputType 'Text' `
            -Title 'Test Column 14'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column14
        $appSettings.Column14Id = $column14.Id
        $appSettings.Column14Name = $column14.Name
        $appSettings.Column14Title = $column14.Title

        Write-Progress -Activity 'Creating fields...' -Status 'Test Column 15'
        $column15 = New-KshColumnGeolocation `
            -AddColumnOptions 8 `
            -Name 'TestColumn15' `
            -Title 'Test Column 15'
        $null = New-KshContentTypeColumn `
            -ContentType $siteContentType1 `
            -Column $column15
        $appSettings.Column15Id = $column15.Id
        $appSettings.Column15Name = $column15.Name
        $appSettings.Column15Title = $column15.Title

        Write-Progress -Activity 'Creating list content types...' -Status 'Test Content Type 1'
        $listContentType1 = New-KshContentType `
            -List $list1 `
            -ContentType $siteContentType1
        $appSettings.ListContentType1Id = $listContentType1.StringId

        Write-Progress -Activity 'Creating list content types...' -Status 'Test Content Type 2'
        $listContentType2 = New-KshContentType `
            -List $list1 `
            -ContentType $siteContentType2
        $appSettings.ListContentType2Id = $listContentType2.StringId

        Write-Progress -Activity 'Creating list content types...' -Status 'Test Content Type 3'
        $listContentType3 = New-KshContentType `
            -List $list1 `
            -ContentType $siteContentType3
        $appSettings.ListContentType3Id = $listContentType3.StringId

        Write-Progress -Activity 'Creating list content types...' -Status 'Test Content Type 4'
        $listContentType4 = New-KshContentType `
            -List $list2 `
            -ContentType $siteContentType4
        $appSettings.ListContentType4Id = $listContentType4.StringId

        Write-Progress -Activity 'Creating list content types...' -Status 'Test Content Type 5'
        $listContentType5 = New-KshContentType `
            -List $list2 `
            -ContentType $siteContentType5
        $appSettings.ListContentType5Id = $listContentType5.StringId

        Write-Progress -Activity 'Creating list content types...' -Status 'Test Content Type 6'
        $listContentType6 = New-KshContentType `
            -List $list2 `
            -ContentType $siteContentType6
        $appSettings.ListContentType6Id = $listContentType6.StringId

        Write-Progress -Activity 'Creating views...' -Status 'Test View 1'
        $view1 = New-KshView `
            -List $list1 `
            -Title 'TestView1' `
            -ViewColumns @(
                'Test Column 1'
                'Test Column 2'
                'Test Column 3'
                'Test Column 4'
                'Test Column 5'
                'Test Column 6'
                'Test Column 7'
                'Test Column 8'
                'Test Column 9'
                'Test Column 10'
                'Test Column 11'
                'Test Column 12'
                'Test Column 13'
                'Test Column 14'
                'Test Column 15'
            )
        $view1 = Update-KshView `
            -Identity $view1 `
            -Title 'Test View 1' `
            -PassThru
        $appSettings.View1Id = $view1.Id
        $appSettings.View1Title = $view1.Title

        Write-Progress -Activity 'Creating views...' -Status 'Test View 2'
        $view2 = New-KshView `
            -List $list1 `
            -Title 'TestView2' `
            -ViewColumns @(
                'Test Column 1'
                'Test Column 2'
                'Test Column 3'
                'Test Column 4'
                'Test Column 5'
                'Test Column 6'
                'Test Column 7'
                'Test Column 8'
                'Test Column 9'
                'Test Column 10'
                'Test Column 11'
                'Test Column 12'
                'Test Column 13'
                'Test Column 14'
                'Test Column 15'
            )
        $view2 = Update-KshView `
            -Identity $view2 `
            -Title 'Test View 2' `
            -PassThru
        $appSettings.View2Id = $view2.Id
        $appSettings.View2Title = $view2.Title

        Write-Progress -Activity 'Creating views...' -Status 'Test View 3'
        $view3 = New-KshView `
            -List $list1 `
            -Title 'TestView3' `
            -ViewColumns @(
                'Test Column 1'
                'Test Column 2'
                'Test Column 3'
                'Test Column 4'
                'Test Column 5'
                'Test Column 6'
                'Test Column 7'
                'Test Column 8'
                'Test Column 9'
                'Test Column 10'
                'Test Column 11'
                'Test Column 12'
                'Test Column 13'
                'Test Column 14'
                'Test Column 15'
            )
        $view3 = Update-KshView `
            -Identity $view3 `
            -Title 'Test View 3' `
            -PassThru
        $appSettings.View3Id = $view3.Id
        $appSettings.View3Title = $view3.Title

        Write-Progress -Activity 'Creating list items...' -Status 'Preparing'
        $userValue1 = New-KshColumnUserValue -LookupId $user1.Id
        $userValue2 = New-KshColumnUserValue -LookupId $user2.Id
        $userValue3 = New-KshColumnUserValue -LookupId $user3.Id

        Write-Progress -Activity 'Creating list items...' -Status 'Preparing'
        $urlValue1 = New-KshColumnUrlValue `
            -Description 'Test Value 1' `
            -Url 'http://www.example.com'
        $urlValue2 = New-KshColumnUrlValue `
            -Description 'Test Value 2' `
            -Url 'http://www.example.com'
        $urlValue3 = New-KshColumnUrlValue `
            -Description 'Test Value 3' `
            -Url 'http://www.example.com'

        Write-Progress -Activity 'Creating list items...' -Status 'Preparing'
        $geolocationValue1 = New-KshColumnGeolocationValue `
            -Latitude 35.689488 `
            -Longitude 139.691706
        $geolocationValue2 = New-KshColumnGeolocationValue `
            -Latitude 34.686297 `
            -Longitude 135.519661
        $geolocationValue3 = New-KshColumnGeolocationValue `
            -Latitude 35.180188 `
            -Longitude 136.906565

        Write-Progress -Activity 'Creating list items...' -Status 'Test List Item 1'
        $item1 = New-KshListItem `
            -List $list1 `
            -Value @{
                Title = 'Test List Item 1'
                TestColumn1 = 'Test Value 1'
                TestColumn2 = 'Test Value 1'
                TestColumn3 = 'Test Value 1'
                TestColumn4 = @('Test Value 1')
                TestColumn5 = 1
                TestColumn6 = 1
                TestColumn7 = [datetime]'10/10/2010'
                TestColumn10 = $true
                TestColumn11 = $userValue1
                TestColumn12 = @($userValue1)
                TestColumn13 = $urlValue1
                TestColumn15 = $geolocationValue1
            }
        $appSettings.ListItem1Id = $item1.Id

        Write-Progress -Activity 'Creating list items...' -Status 'Test List Item 2'
        $item2 = New-KshListItem `
            -List $list1 `
            -Value @{
                Title = 'Test List Item 2'
                TestColumn1 = 'Test Value 2'
                TestColumn2 = 'Test Value 2'
                TestColumn3 = 'Test Value 2'
                TestColumn4 = @('Test Value 2')
                TestColumn5 = 2
                TestColumn6 = 2
                TestColumn7 = [datetime]'12/20/2016'
                TestColumn10 = $true
                TestColumn11 = $userValue2
                TestColumn12 = @($userValue2)
                TestColumn13 = $urlValue2
                TestColumn15 = $geolocationValue2
            }
        $appSettings.ListItem2Id = $item2.Id

        Write-Progress -Activity 'Creating list items...' -Status 'Test List Item 3'
        $item3 = New-KshListItem `
            -List $list1 `
            -Value @{
                Title = 'Test List Item 3'
                TestColumn1 = 'Test Value 3'
                TestColumn2 = 'Test Value 3'
                TestColumn3 = 'Test Value 3'
                TestColumn4 = @('Test Value 1', 'Test Value 2', 'Test Value 3')
                TestColumn5 = 1
                TestColumn6 = 1
                TestColumn7 = [datetime]'12/20/2016'
                TestColumn10 = $true
                TestColumn11 = $userValue3
                TestColumn12 = @($userValue1, $userValue2, $userValue3)
                TestColumn13 = $urlValue3
                TestColumn15 = $geolocationValue3
            }
        $appSettings.ListItem3Id = $item3.Id

        Write-Progress -Activity 'Updating list items...' -Status 'Preparing'
        $lookupValue1 = New-KshColumnLookupValue -LookupId $item1.Id
        $lookupValue2 = New-KshColumnLookupValue -LookupId $item2.Id
        $lookupValue3 = New-KshColumnLookupValue -LookupId $item3.Id

        Write-Progress -Activity 'Updating list items...' -Status 'Test List Item 1'
        $item1 = Update-KshListItem `
            -Identity $item1 `
            -Value @{
                TestColumn8 = $lookupValue1
                TestColumn9 = @($lookupValue1)
            } `
            -PassThru

        Write-Progress -Activity 'Updating list items...' -Status 'Test List Item 2'
        $item2 = Update-KshListItem `
            -Identity $item2 `
            -Value @{
                TestColumn8 = $lookupValue2
                TestColumn9 = @($lookupValue2)
            } `
            -PassThru

        Write-Progress -Activity 'Updating list items...' -Status 'Test List Item 3'
        $item3 = Update-KshListItem `
            -Identity $item3 `
            -Value @{
                TestColumn8 = $lookupValue3
                TestColumn9 = @($lookupValue1, $lookupValue2, $lookupValue3)
            } `
            -PassThru

        Write-Progress -Activity 'Creating attachments...' -Status 'Test File 1'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile1')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $attachmentFile1 = Save-KshAttachmentFile `
            -ListItem $item1 `
            -Content $stream `
            -FileName 'TestFile1.txt' `
            -PassThru
        $appSettings.AttachmentFile1Name = $attachmentFile1.FileName

        Write-Progress -Activity 'Creating attachments...' -Status 'Test File 2'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile2')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $attachmentFile2 = Save-KshAttachmentFile `
            -ListItem $item1 `
            -Content $stream `
            -FileName 'TestFile2.txt' `
            -PassThru
        $appSettings.AttachmentFile2Name = $attachmentFile2.FileName

        Write-Progress -Activity 'Creating attachments...' -Status 'Test File 3'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile3')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $attachmentFile3 = Save-KshAttachmentFile `
            -ListItem $item1 `
            -Content $stream `
            -FileName 'TestFile3.txt' `
            -PassThru
        $appSettings.AttachmentFile3Name = $attachmentFile3.FileName

        Write-Progress -Activity 'Creating folders...' -Status 'Test Folder 1'
        $folder1 = New-KshFolder `
            -Folder $rootFolder2 `
            -FolderName 'Test Folder 1'
        $appSettings.Folder1Url = $folder1.ServerRelativeUrl
        $appSettings.Folder1Name = $folder1.Name

        Write-Progress -Activity 'Creating folders...' -Status 'Test Folder 2'
        $folder2 = New-KshFolder `
            -Folder $folder1 `
            -FolderName 'Test Folder 2'
        $appSettings.Folder2Url = $folder2.ServerRelativeUrl
        $appSettings.Folder2Name = $folder2.Name

        Write-Progress -Activity 'Creating files...' -Status 'Test Folder 3'
        $folder3 = New-KshFolder `
            -Folder $folder1 `
            -FolderName 'Test Folder 3'
        $appSettings.Folder3Url = $folder3.ServerRelativeUrl
        $appSettings.Folder3Name = $folder3.Name

        Write-Progress -Activity 'Creating files...' -Status 'Test Folder 4'
        $folder4 = New-KshFolder `
            -Folder $folder3 `
            -FolderName 'Test Folder 4'
        $appSettings.Folder4Url = $folder4.ServerRelativeUrl
        $appSettings.Folder4Name = $folder4.Name

        Write-Progress -Activity 'Creating files...' -Status 'Test File 1'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile1')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $file1 = Save-KshFile `
            -Folder $folder1 `
            -Content $stream `
            -FileName 'TestFile1.txt' `
            -PassThru
        $appSettings.File1Url = $file1.ServerRelativeUrl
        $appSettings.File1Name = $file1.Name

        Write-Progress -Activity 'Creating files...' -Status 'Test File 2'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile2')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $file2 = Save-KshFile `
            -Folder $folder1 `
            -Content $stream `
            -FileName 'TestFile2.txt' `
            -PassThru
        $appSettings.File2Url = $file2.ServerRelativeUrl
        $appSettings.File2Name = $file2.Name

        Write-Progress -Activity 'Creating files...' -Status 'Test File 3'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile3')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $file3 = Save-KshFile `
            -Folder $folder1 `
            -Content $stream `
            -FileName 'TestFile3.txt' `
            -PassThru
        $appSettings.File3Url = $file3.ServerRelativeUrl
        $appSettings.File3Name = $file3.Name

        Write-Progress -Activity 'Creating files...' -Status 'Test File 4'
        $buffer = [System.Text.Encoding]::UTF8.GetBytes('TestFile4')
        $stream = New-Object System.IO.MemoryStream(@(, $buffer))
        $file4 = Save-KshFile `
            -Folder $folder4 `
            -Content $stream `
            -FileName 'TestFile4.txt' `
            -PassThru
        $appSettings.File4Url = $file4.ServerRelativeUrl
        $appSettings.File4Name = $file4.Name

        Write-Output $appSettings
    }

}

function Uninstall-TestSite {

    [CmdletBinding()]
    param (
        [Parameter(Mandatory = $true)]
        [uri]
        $Url,
        [Parameter(Mandatory = $true)]
        [string]
        $UserName,
        [Parameter(Mandatory = $true)]
        [string]
        $Password,
        [Parameter(Mandatory = $true)]
        [string]
        $DomainName
    )

    process {

        $authorityUrl = $Url.GetLeftPart([System.UriPartial]::Authority)
        $adminUrl = $authorityUrl.Replace('.sharepoint.com', '-admin.sharepoint.com')

        $credential = New-Object System.Net.NetworkCredential("$UserName@$DomainName", $Password)
        $credential = New-Object System.Management.Automation.PSCredential($credential.UserName, $credential.SecurePassword)

        Write-Progress -Activity 'Sign in...' -Status 'Processing'
        Connect-KshSite -Url $adminUrl -Credential $credential

        Write-Progress -Activity 'Deleting site collection...' -Status 'Processing'
        Get-KshTenantSiteCollection -SiteCollectionUrl $Url | Remove-KshTenantSiteCollection
        Get-KshTenantDeletedSiteCollection -SiteCollectionUrl $Url | Remove-KshTenantDeletedSiteCollection

    }

}
