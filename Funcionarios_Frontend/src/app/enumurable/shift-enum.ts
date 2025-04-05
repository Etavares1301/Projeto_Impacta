export enum ShiftEnum {
  MORNING = 1,
  AFTERNON = 2,
  NIGHT = 3,
}

export const descriptionShiftEnum: Record<ShiftEnum, string> = {
  [ShiftEnum.MORNING]: "Manhã",
  [ShiftEnum.AFTERNON]: 'Tarde',
  [ShiftEnum.NIGHT]: 'Noite',
}
