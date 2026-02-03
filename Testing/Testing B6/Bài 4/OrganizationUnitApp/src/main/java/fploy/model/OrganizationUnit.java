package fploy.model;

public class OrganizationUnit {
    private String unitId;
    private String unitName;
    private String unitDescription;
    private int orgId;

    public OrganizationUnit() {
    }

    public OrganizationUnit(String unitId, String unitName, String unitDescription, int orgId) {
        this.unitId = unitId;
        this.unitName = unitName;
        this.unitDescription = unitDescription;
        this.orgId = orgId;
    }

    public String getUnitId() {
        return unitId;
    }

    public void setUnitId(String unitId) {
        this.unitId = unitId;
    }

    public String getUnitName() {
        return unitName;
    }

    public void setUnitName(String unitName) {
        this.unitName = unitName;
    }

    public String getUnitDescription() {
        return unitDescription;
    }

    public void setUnitDescription(String unitDescription) {
        this.unitDescription = unitDescription;
    }

    public int getOrgId() {
        return orgId;
    }

    public void setOrgId(int orgId) {
        this.orgId = orgId;
    }
}
