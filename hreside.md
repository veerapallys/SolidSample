flowchart TD

    %% Permanent credentials
    A[App Registered]:::perm --> B[API Key + Secret Issued]:::perm

    %% OAuth flow
    C[User Login via OAuth]:::temp --> D[Authorization Code]:::temp
    D --> E[Access Token + Refresh Token]:::temp

    %% Using access token
    E --> F[GET /locations]:::temp
    F --> G[locationId]:::perm

    E --> H[GET /devices?locationId]:::temp
    H --> I[deviceId(s)]:::perm

    %% Expiration handling
    J[Access Token Expired]:::temp --> K[Use Refresh Token]:::temp
    K --> L[New Access Token]:::temp

    M[Refresh Token Expired]:::temp --> N[User Login Again]:::temp
    N --> O[New Tokens]:::temp

    %% Styles
    classDef perm fill:#b6e3b6,stroke:#2d7a2d,stroke-width:2px;
    classDef temp fill:#ffd59e,stroke:#b36b00,stroke-width:2px;
