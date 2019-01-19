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
