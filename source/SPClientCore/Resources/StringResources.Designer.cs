﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Karamem0.SharePoint.PowerShell.Resources {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class StringResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal StringResources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Karamem0.SharePoint.PowerShell.Resources.StringResources", typeof(StringResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   すべてについて、現在のスレッドの CurrentUICulture プロパティをオーバーライドします
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Cannot resolve Tenant ID from resource URL. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string ErrorCannotResolveTenantId {
            get {
                return ResourceManager.GetString("ErrorCannotResolveTenantId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Not connected to SharePoint Server. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string ErrorNotConnected {
            get {
                return ResourceManager.GetString("ErrorNotConnected", resourceCulture);
            }
        }
        
        /// <summary>
        ///   &apos;{0}&apos; is invalid. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string ErrorValueIsInvalid {
            get {
                return ResourceManager.GetString("ErrorValueIsInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   &apos;{0}&apos; is not a absolute URL. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string ErrorValueIsNotAbsoluteUrl {
            get {
                return ResourceManager.GetString("ErrorValueIsNotAbsoluteUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   &apos;{0}&apos; is not a relative URL. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string ErrorValueIsNotRelativeUrl {
            get {
                return ResourceManager.GetString("ErrorValueIsNotRelativeUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   &apos;{0}&apos; should not be null. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string ErrorValueShouldNotBeNull {
            get {
                return ResourceManager.GetString("ErrorValueShouldNotBeNull", resourceCulture);
            }
        }
    }
}
