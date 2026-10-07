# System architecture

## Architectural principle

The public portfolio is the product. Collection and LLM assistance are replaceable tools around its content boundary, not prerequisites for rendering or deployment.

## Baseline

Use .NET 10 Blazor WebAssembly and GitHub Pages. Use Razor components for presentation, ordinary .NET code for loading and validation integration, and generated JSON as the public runtime boundary.

## Repository shape

```text
src/
  content/
    schema/
    profile/
    experience/
    education/
    projects/
    snippets/
    evidence/
  Ulfbou.Site/
    Components/
      Blocks/
    Pages/
    Services/
    wwwroot/
      data/generated/
      images/
tools/
  Portfolio.ContentCompiler/
  Portfolio.RepositoryCollector/     phase 6 only
  Portfolio.Curation/                phase 7+ only
Tests/
  Portfolio.Content.Tests/
  Ulfbou.Site.Tests/
```

Exact project names may follow existing repository conventions. Directory responsibilities and boundaries are normative.

## Public data flow

```text
approved authored source in src/content/
  -> schema and semantic validation
  -> publication filtering
  -> generated JSON
  -> one portfolio data service
  -> route-specific view models
  -> reusable screen and print blocks
```

## Optional evidence flow

```text
approved repository scope
  -> deterministic evidence package
  -> optional bounded LLM suggestions
  -> explicit human review
  -> approved authored source
  -> existing public data flow
```

Collectors and LLM workflows never write directly to generated public data.

## Reading depth

The same approved content model supports `overview`, `detail`, and `evidence`. Depth changes disclosure, not truth. URLs may preserve requested depth, but essential context must not require a visitor to choose a mode before understanding the page.

## Static hosting constraints

- direct navigation and refresh work on GitHub Pages;
- no server-side runtime is required;
- base paths do not assume domain-root hosting internally;
- runtime fetches use the application base address;
- print uses the same approved facts as screen views;
- failure to load optional evidence does not break core portfolio content.

## Tool policy

- .NET remains the portfolio-core language;
- deterministic schema and semantic validation establish publication safety;
- Python may be used for collectors, fixtures, analysis, or curation where it is the clearest fit;
- JavaScript is limited to necessary browser integration;
- no tool may bypass content, authority, provenance, or publication contracts.
