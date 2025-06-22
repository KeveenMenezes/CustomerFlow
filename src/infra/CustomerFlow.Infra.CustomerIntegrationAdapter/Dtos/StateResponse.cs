namespace CustomerFlow.Infra.CustomerIntegrationAdapter.Dtos;

public record StateResponse(StateResponseDTO Data);

public record StateResponseDTO(
    List<StateInformationDTO> BmgMoneyStates,
    List<StateInformationDTO> WebBankStates
);

public record StateInformationDTO(
    string StateName,
    string StateAbbreviation
);
