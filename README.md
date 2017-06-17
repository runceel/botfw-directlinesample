# botfw-directlinesample

このリポジトリは、Xamarin.FormsでBot FrameworkのDirectLineを使うサンプルプログラムです。

いくつかポイントを解説します。

# Point

## .NET Standard

DirectLineのNuGetパッケージは最新版だと.NET Standardに対応しています。そのためPCLのXamarin.Formsのプロジェクトからは参照できませんでした。
そのため.NET Standard 1.4に変換してパッケージを追加しています。

## Microsoft.Rest.ClientRuntime

DirectLineのパッケージで使ってるっぽいのにDirectLineをNuGetから追加しただけでは追加されないパッケージなので手動で追加しています…。

## Secrets.cs

DirectLineのAPIキーを設定するファイルです。cloneした後手動で以下のような内容で追加してください。

```cs
using System;
namespace DirectLineSample
{
    static class Secrets
    {
        public static string DirectLineApiKey { get; } = "ここにあなたのキーを追加";
    }
}
```

