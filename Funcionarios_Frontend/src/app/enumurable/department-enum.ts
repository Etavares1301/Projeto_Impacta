export enum DepartmentEnum {
  HR = 1,
  FINANCIAL = 2,
  PURCHASING = 3,
  CUSTOMER_SERVICE = 4,
  MAINTENANCE = 5
}

export const descriptionDepartmentEnum: Record<DepartmentEnum, string> = {
  [DepartmentEnum.HR]: "Recursos Humanos",
  [DepartmentEnum.FINANCIAL]: 'Financeiro',
  [DepartmentEnum.PURCHASING]: 'Compras',
  [DepartmentEnum.CUSTOMER_SERVICE]: 'Atendimento',
  [DepartmentEnum.MAINTENANCE]: 'Zeladoria'
}
