with import <nixpkgs> {};

mkShell {
  name = "dotnet-env";
  packages = [
    glibc
    icu.dev
    openssl
    stdenv.cc.cc.lib
    (with dotnetCorePackages; combinePackages [
      sdk_3_1
      sdk_6_0
    ])
  ];
}
