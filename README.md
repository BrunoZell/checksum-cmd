# chksm

This simple command line utility helps to calculate file checksums. It is built specifically to be the go-to solution for Windows computers, but indeed it's platform independent as it is build on .Net-Core.

## Usage

You just need to secify the hash algorithm and the file name to compute a checksum. The checksum is written to the standard output:

```
> chksm sha1 setup.exe
efb7e4f10bc7aedefa4cbfb7bc208f93c02b47a3
```

Currently the following hash algorithms are supported:

- SHA1
- SHA256
- SHA384
- SHA512
- MD5

**Feel free to contribute and add to the list!**

## Build

In the project directory, you can build this project specifically for your environment so it will even run on computers where you don't have the .Net-Core runtime installed:

```
> dotnet publish -c Release -r win10-x64
> dotnet publish -c Release -r ubuntu.16.10-x64
```