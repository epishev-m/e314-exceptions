# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.1.2] - 2025-03-03

### Fixed

- Fix .asmdef names

## [1.1.0] - 2025-02-24

### Added

- Added `ObjDisposedException` to handle the use of an object after it has been released.

## [1.0.0] - 2025-02-22

### Added

- Base Exception Class:
  - Introduced DetailedException as the base class for all custom exceptions in the module.
  - Includes properties such as `ErrorCode`, `ErrorData`, `FileName`, `MethodName` and `LineNumber` to provide detailed error information.
- Specialized Exceptions:
  - Added `ArgException` for general argument-related errors.
  - Added `ArgNullException` for handling null arguments.
  - Added `ArgOutOfRangeException` for handling arguments that fall outside valid ranges.
  - Added `InvOpException` for handling invalid operations due to object state.
