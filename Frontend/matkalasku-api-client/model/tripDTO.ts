/**
 * MatkaLasku
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */

export interface TripDTO { 
    id?: number;
    companyId?: number;
    departure?: Date;
    recurrence?: Date;
    recipient?: string;
    purpose?: string;
    distanceInKM?: number;
    locationDeparture?: string;
    locationDestination?: string;
    description?: string;
    passengerCount?: number;
}