export interface SprBaseEntity{
    id: number
    parentId?:number
    parentName?: string
    code: string
    fullName: string
    shortName: string
    onDate?: Date
    toDate?: Date
}