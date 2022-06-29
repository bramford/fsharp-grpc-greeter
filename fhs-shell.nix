{ pkgs ? import <nixpkgs> {} }:

(pkgs.buildFHSUserEnv {
  name = "dotnet";

  targetPkgs = pkgs: [
    pkgs.glibc
    pkgs.icu.dev
    pkgs.openssl
    pkgs.stdenv.cc.cc.lib
    (with pkgs.dotnetCorePackages; combinePackages [
      sdk_3_1
      sdk_6_0
    ])
  ];

}).env
