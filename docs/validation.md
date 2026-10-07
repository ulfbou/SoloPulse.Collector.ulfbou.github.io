# Validation and evidence

## Canonical sequence

The repository establishes one concrete command for each step as project names become real. Local documentation and CI use the same commands in the same order:

```bash
dotnet restore
dotnet build --no-restore
dotnet test --no-build
# run the repository-defined content compiler and semantic validation
# run route, direct-refresh, and static-link checks
# run public-output and semantic non-regression checks
```

## Mandatory portfolio gates

- source schema and semantic validation;
- duplicate ID, unknown type/state, malformed metadata, reference, and internal-route failures;
- public output contains no candidate or private-build-only content;
- representative valid and invalid fixtures;
- unchanged approved source produces semantically equivalent runtime data;
- required routes and unknown-slug behavior;
- GitHub Pages direct navigation and refresh fallback;
- keyboard, headings, focus, accessible names, alternatives, and zoom resilience;
- desktop, mobile, and print review;
- external-link release check;
- semantic non-regression against approved facts and contracts.

## Additional gates by phase

Collector and LLM checks are introduced only with their phases. They must not become prerequisites for building, testing, deploying, or viewing the core portfolio.

Phase 6 adds collector determinism, exclusions, traceability, partial/failure behavior, and evidence-contract validation. Phase 7 adds bounded-input, provenance, review-decision, rejected-output exclusion, and no-direct-publication checks.

## Evidence format

Every Acceptance Ready criterion has a named check, command or review record, result, and evidence location. Unknown mandatory results fail the gate. Manual visual and content approvals identify reviewer and reviewed revision.
